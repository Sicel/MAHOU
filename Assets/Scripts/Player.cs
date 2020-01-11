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

    [SerializeField] private Camera camera;
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
        CurrentPlayerState = PlayerState.Moving;
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentPlayerState)
        {
            case PlayerState.Targetting:
                Targeting();
                break;
            default:
                break;
        }
    }

    private void Targeting()
    {
        selectedSpell.OnBeforeTargetting(camera.ScreenPointToRay(Mouse.current.position.ReadValue()));

        if (selectedSpell.TargetPosition != Vector3.zero)
            targeter.gameObject.transform.position = selectedSpell.TargetPosition + new Vector3(0, 2, 0);

        selectedSpell.OnTargetting();
    }

    public void NextState(InputAction.CallbackContext context)
    {
        if (context.performed)
            CurrentPlayerState = CurrentPlayerState.Next();
    }

    public void PreviousState(InputAction.CallbackContext context)
    {
        if (context.performed)
            CurrentPlayerState = CurrentPlayerState.Prev();
    }
}
