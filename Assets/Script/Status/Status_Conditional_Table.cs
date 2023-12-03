using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Status_Conditional_Table: MonoBehaviour
{
    
    public Dictionary<FavorableConditions, Status> Dict = new Dictionary<FavorableConditions, Status>();
    [Serializable]
    public class pair
    {
        public FavorableConditions condition;
        public Status status;
    }

    [Header("Add condition")]
    [SerializeField] public List<pair> Condition_Status;

    void Start()
    {
        foreach (pair items in Condition_Status)
        {
            Dict.Add(items.condition, items.status);
        }
    }
}
