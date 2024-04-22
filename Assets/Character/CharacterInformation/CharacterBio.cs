using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create the object status
[CreateAssetMenu(fileName = "Character", menuName = "Bio", order = 1)]
[System.Serializable]
public class CharacterBio : ScriptableObject
{
    // Character attributes
    [Header("Character basic information")]
    [SerializeField] public string CharacterName;
    [SerializeField] public string CharacterDescription;

    [Header("Bio")]
    [SerializeField] public string Bio;

    [Header("Background")]
    [SerializeField] public string Background;

}
