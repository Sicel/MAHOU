using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Targetting : MonoBehaviour
{
    [SerializeField] private Camera camera; // Camera to use if casting ray from camera
    [SerializeField] private Vector3 targetPosition;

    public void OnTargetting()
    {
        Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, // Ray being sent out from camera
                            out hit, // What ray hits
                            100, // Ray Distance
                            LayerMask.GetMask("Ground") // The layer the ray can interact with
                            )
            )
        {
            targetPosition = hit.point; // sets target to where the ray hit
        }
    }
}
