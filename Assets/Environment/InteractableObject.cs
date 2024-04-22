using System.Collections.Generic;
using System.Linq;
using UnityEngine;


// This is a base class for all interactable objects in the game
public class InteractableObject : MonoBehaviour, IInteraction
{

    [Header("Interactable field")]
    [SerializeField] public List<Status> status;
    [SerializeField] public bool isPlayerInvestigated = false;
    [SerializeField] public Inventory inventory;
    [SerializeField] private Item weapon;

    [SerializeField] private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    // Interact method
    public void Interact()
    {
        print("Player Interact with the object" + gameObject.name);
        if(weapon != null)
        {
            player.inventory.AddItem(weapon);
            weapon = null;
        }
    }

    public void PutWeapon(Item item)
    {
        if (weapon != null) { return; }
        weapon = item;
    }

    public void TakeWeapon()
    {
        print("NPC pick away the weapon");
        if (weapon == null) { return; }
        weapon = null;
    }

/*

    protected virtual void Awake()
    {
        player = (Player) FindObjectOfType(typeof(Player));
        inventory = new Inventory();
    }

    // Method to add item
    public virtual void AddItem(Item item)
    {
        inventory.AddItem(item);
    }

    // Use method to interact with the object
    public virtual void Interact() // General interact method
    {
        if (!isInvestigated)
        {
            player.Action = player.Action - 1;
        }

        *//*// Take items from inventory
        Item item = inventory.TakeItem(0);

        if (item == null) { return; }

        player.bag.AddItem(item);*//*

        if (vol.Count >= 0 && player.Cules.Contains(player.clues2))
        {
            player.bag.AddItem(vol[0]);
            vol.RemoveAt(0);
        }

        isInvestigated = true;

    }
    public virtual void Interact(GameObject target) // Geheral interact method with object
    {

    }

    //calculate the probability of showing the status
    public float showStatusProbability(Status objStatus, List<FavorableConditions> condList)
    {
        List<FavorableConditions> statusCondList = objStatus.conditions;
        int count = statusCondList.Intersect(condList).Count();
        float probability = objStatus.bonusDiscoveryRate + objStatus.discoveryRate * count + (float)player.Investigative / 100;
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
        return true;
    }

    public virtual void AddCondition(FavorableConditions conditions)
    {
        
    }

    public virtual void ReomveCondition(FavorableConditions conditions)
    {
        
    }*/
}
