using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Character : MonoBehaviour
{
    // Character attributes
    protected uint HP = 50; // Health point
    protected Inventory bag; // The bag of the character
    

    // Damage the character, return true if the character is still alive
    public bool damage(uint damage)
    {
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
