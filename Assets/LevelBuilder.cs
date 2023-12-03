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
        public List<FavorableConditions> condition;
    }
    [Header("For gameobject")]
    [SerializeField] public List<LevelItems> SetupList;
    [Header("For player")]
    [SerializeField] public LevelItems Player;
    // Start is called before the first frame update
    void Start()
    {
        initSetupList();
        initPlayerInventory();
    }

    // TODO
    private void initPlayerInventory()
    {
        throw new NotImplementedException();
    }

    private void initSetupList()
    {
        foreach (LevelItems items in SetupList)
        {
            IStatusProperty target = items.gameObject.GetComponent<IStatusProperty>();
            IFavorableConditionsProperty prop = items.gameObject.GetComponent<IFavorableConditionsProperty>();

            // Adding the status into the gameobjcet
            if (target != null)
            {
                foreach (var status in items.status)
                {
                    target.AddStatus(status);
                }
            }

            // Adding the condition into the gamebObject
            if (prop != null)
            {
                foreach (var condition in items.condition)
                {
                    prop.AddCondition(condition);
                }
            }
        }
    }
}
