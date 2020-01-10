using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    Moving,
    Targetting,
    Casting
}

public class Player : Entity
{
    [Header("Player")]

    [SerializeField] private SpellList SpellList;
    [SerializeField] private Spell selectedSpell;
    [SerializeField] private ObjectStates objectStates;
    [SerializeField] private GameObject targeter;

    public PlayerState CurrentPlayerState 
    { 
        get { return objectStates.PlayerState; } 
        set { objectStates.PlayerState = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextState(InputAction.CallbackContext context)
    {
        int enumLength = System.Enum.GetNames(typeof(PlayerState)).Length;
        CurrentPlayerState++;

        if ((int)CurrentPlayerState >= enumLength)
            CurrentPlayerState = (PlayerState)enumLength;

    }

    public void PreviousState(InputAction.CallbackContext context)
    {
        CurrentPlayerState--;

        if (CurrentPlayerState < 0)
            CurrentPlayerState = 0;
    }
}
