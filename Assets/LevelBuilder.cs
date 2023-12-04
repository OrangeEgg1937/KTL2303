using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The class is to set up all the status, condition to gameobject
[Serializable]
public class LevelBuilder : MonoBehaviour
{
    [Serializable]
    public class LevelItems
    {
        public GameObject gameObject;
        public List<Status> status;
        public List<FavorableConditions> cules;
        public List<Item> items;
    }
    [Header("For gameobject")]
    [SerializeField] public List<LevelItems> SetupList;
    [Header("For player")]
    [SerializeField] public LevelItems PlayerObject;
    [Header("For current items list:")]
    [SerializeField] private List<Item> ItemsList;
    [Header("For current status:")]
    [SerializeField] protected List<Status> StatusList;
    [Header("For environment object:")]
    [SerializeField] protected List<GameObject> EnvList;
    [Header("Conditional List")]
    [SerializeField] protected List<FavorableConditions> CondList;

    // Start is called before the first frame update
    void Start()
    {
        // initSetupList();
        initItems();
        initPlayerInventory();
    }

    private void initItems()
    {
        foreach (var item in ItemsList)
        {
            if (item == null) return;

            // Clear the current list
            item.status.Clear();

            // init the list with initStatus
            item.status = new List<Status>(item.initStatus);
        }
    }

    private void initPlayerInventory()
    {
        Player dest = PlayerObject.gameObject.GetComponent<Player>();
        // Initial status to player
        foreach (var status in PlayerObject.status)
        {
            if (status == null) continue;
            dest.AddStatus(status);
        }

        // Initial clues to player
        foreach (var item in PlayerObject.cules)
        {
            if (item == null) continue;
            dest.Cules.Add(item);
        }

        // Initial items to player
        foreach(var item in PlayerObject.items)
        {
            if (item == null) continue;
            dest.bag.AddItem(item);
        }
    }

    public Item GetItemById(int id)
    {
        // prevent inaccessable index
        if (id >= ItemsList.Count)
        {
            return null;
        }
        return ItemsList[id];
    }

    public void AddItemToItemList(Item item)
    {
        ItemsList.Add(item);
    }

    public void AddConditionToItemInItemList(FavorableConditions conditions, int index)
    {
        ItemsList[index].Condition.Add(conditions);
    }

    public void AddStatisToItemInItemList(Status status, int index)
    {
        ItemsList[index].status.Add(status);
    }

    public Status GetStatusById(int id)
    {
        // prevemt inaccessible index
        if (id >= StatusList.Count)
        {
            return null;
        }
        return StatusList[id];
    }

    public List<GameObject> GetEnvObjectsList()
    {
        return EnvList;
    }

    public GameObject GetGameObjectByID(int id)
    {
        return EnvList[id];
    }

    // Get condList
    public List<FavorableConditions> GetConditionsList()
    {
        return CondList;
    }

    public FavorableConditions GetConditionsById(int id)
    {
        return CondList[id];
    }

    public bool CheckConditionsInItem(int c_id, int itemID)
    {
        foreach (var status in ItemsList[itemID].status)
        {
            if (status.conditions.Contains(CondList[c_id])) { return true; }
        }
        return false;
    }

    public bool CheckStatusInItemByID(int s_id, int itemID)
    {
        return ItemsList[itemID].status.Contains(StatusList[s_id]);
    }

    public bool CheckStatusInItem(int s_id, Item item)
    {
        return item.status.Contains(StatusList[s_id]);
    }

    public void AddMurderStatus(Item item)
    {
        item.status.Add(StatusList[0]);
    }

    public Item FindItemByName(String name)
    {
        foreach (var item in ItemsList)
        {
            if (item.name.Equals(name))
            {
                return item;
            }
        }
        return null;
    }

}
