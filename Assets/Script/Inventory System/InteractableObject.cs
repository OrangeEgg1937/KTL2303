using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Playables;
using UnityEngine;
using System.Linq;

// Set a generic Unity event class


// This is a base class for all interactable objects in the game
public abstract class InteractableObject : MonoBehaviour, IStatusProperty, IFavorableConditionsProperty
{
    // Interactable object attributes
    // We don't need the name of the object
    // because we can get it by using gameObject.name from MonoBehaviour
    
    public const int INTERACTABLE_OBJECT_LAYER_CODE = 6;

    protected bool isUpgardeable; // Can the object be upgraded
    [Header("Interactable field")]
    [SerializeField] protected List<Status> status;
    protected bool isInvestigated = false;

    private Player ability;

    // Constructor
    protected InteractableObject(bool upgardeable)
    {
        isUpgardeable = upgardeable;
    }

    protected virtual void Awake()
    {
        ability = (Player) FindObjectOfType(typeof(Player));
    }


    // Use method to interact with the object
    public virtual void Interact() // General interact method
    {
        if (!isInvestigated)
        {
            var player = FindObjectOfType<Player>();
            player.Action = player.Action - 1;
        }

    }
    public virtual void Interact(GameObject target) // Geheral interact method with object
    {

    }

    //calculate the probability of showing the status
    public float showStatusProbability(Status objStatus, List<FavorableConditions> condList)
    {
        List<FavorableConditions> statusCondList = objStatus.conditions;
        int count = statusCondList.Intersect(condList).Count();
        float probability = objStatus.bonusDiscoveryRate + objStatus.discoveryRate * count + (float)ability.Investigative / 100;
        if (probability > 1)
            probability = 1;
        return probability;
    }

    // Upgrading the object
    public abstract void Upgrade(GameObject source);

    // Check the input status is exist in the list or not
    public bool CheckStatus(Status status)
    {
        print("This status is:" + this.status.Contains(status));
        return this.status.Contains(status);
    }

    public void AddStatus(Status status)
    {
        // If the status not in the object list, add it into the list
        if (!CheckStatus(status)) this.status.Add(status);
    }

    public void RemoveStatus(Status status)
    {
        // If the status in the object list, remove it from the list
        if (CheckStatus(status))
        {
            int index = this.status.IndexOf(status);
            this.status.RemoveAt(index);
        }
    }

    public abstract bool CheckStatus(Status status, FavorableConditions conditions);

    public virtual bool CheckCondition(FavorableConditions conditions)
    {
        throw new System.NotImplementedException();
    }

    public virtual void AddCondition(FavorableConditions conditions)
    {
        throw new System.NotImplementedException();
    }

    public virtual void ReomveCondition(FavorableConditions conditions)
    {
        throw new System.NotImplementedException();
    }
}
