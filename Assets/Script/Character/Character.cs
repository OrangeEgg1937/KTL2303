using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Character : MonoBehaviour
{
    // Character attributes
    [Header("Character Attributes")]
    [SerializeField] private uint HP = 50; // Health point
    [SerializeField] public bool isDead = false; // Damage of the character
    [SerializeField] private Inventory bag; // The bag of the character

    // Character nearby environment
    [Header("Character Nearby Environment")]
    [SerializeField] private Transform interactionPoint; // The interaction point of the character
    [SerializeField] private float interactionRadius = 1f; // The interaction radius of the character
    [SerializeField] private List<InteractableEnv> nearbyEnv; // The list of nearby environment objects

    // <Constructor>
    protected Character() { }
    protected Character(uint HP)
    {
        this.HP = HP;
    }
    protected Character(uint HP, Inventory bag)
    {
        this.HP = HP;
        this.bag = bag;
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

}
