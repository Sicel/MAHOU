using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor
{
    Player player;
    PlayerState playerState;

    private void OnEnable()
    {
        player = (Player)target;
        playerState = player.CurrentPlayerState;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        playerState = (PlayerState)EditorGUILayout.EnumPopup("Player State", playerState);
    }
}
