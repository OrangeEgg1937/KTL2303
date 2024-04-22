using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
abstract public class Character : MonoBehaviour, IStatusProperty
{
    // Character information
    [SerializeField] private CharacterBio character_bio;

    // Character attributes
    [Header("Character Attributes")]
    public uint HP = 50; // Health point
    public bool isDead = false; // living of the character
    public GameObject model;
    public Inventory inventory; // The bag of the character


    // Character control attributes
    [Header("Control Attributes")]
    public float movementSpeed = 2.0f;

    // Character nearby environment
    [Header("Character Nearby Environment")]
    [SerializeField] protected float searchingDistance = 1f; // The interaction radius of the character
    [SerializeField] protected Collider[] nearbyObject; // The list of nearby environment objects
    [SerializeField] protected int numOfNearbyObject = 0;
    [SerializeField] protected LayerMask interactionLayerMask;

    // Character scenario
    [Header("Character Scenario")]
    [SerializeField] protected Scenario[] scenarioList;
    [SerializeField] protected Scenario currentScenario;

    // <Constructor>
    protected Character() { }
    protected Character(uint HP)
    {
        this.HP = HP;
    }
    protected Character(uint HP, Inventory bag)
    {
        this.HP = HP;
        this.inventory = bag;
    }

    // Damage the character, return true if the character is still alive
    public bool GetDamage(uint damage)
    {
        if(isDead) return false;
        if (HP > damage)
        {
            HP -= damage;
            return true;
        }
        else
        {
            HP = 0;
            return false;
        }
    }

    // Update the currentScenario dialog
    public void UpdateScenario(Scenario scenario)
    {
        currentScenario = scenario;
    }

    public abstract bool CheckStatus(Status status);
    public abstract bool CheckStatus(Status status, FavorableConditions conditions);
    public abstract void AddStatus(Status status);
    public abstract void RemoveStatus(Status status);
}
