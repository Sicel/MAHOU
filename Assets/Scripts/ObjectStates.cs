using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object States", menuName = "Utils/Object States")]
public class ObjectStates : ScriptableObject
{
    [SerializeField] private PlayerState currentPlayerState = PlayerState.Moving;

    public PlayerState PlayerState 
    {
        get { return currentPlayerState; }
        set { currentPlayerState = value; }
    }
}
