using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    [SerializeField] private float normalSpeed = 5.0f;
    [SerializeField, Range(1.5f, 2.5f)] private float sprintSpeedMultiplier = 1.5f;

    private Vector2 direction = Vector2.zero;
    private Vector3 movement = Vector2.zero;

    private float sprintSpeed { get { return normalSpeed * sprintSpeedMultiplier; } }

    private Vector3 cameraForward { 
        get 
        {
            Vector3 forward = new Vector3(camera.transform.forward.x, 0, camera.transform.forward.z);
            return forward.normalized; 
        } 
    }

    private Vector3 cameraRight { 
        get 
        {
            Vector3 right = new Vector3(camera.transform.right.x, 0, camera.transform.right.z);
            return right.normalized; 
        } 
    
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Walk(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        movement = Vector3.zero;
        //movement = new Vector3(direction.x, 0, direction.y) * normalSpeed;

        if (direction.x > 0)
            movement += cameraRight * normalSpeed;
        else if (direction.x < 0)
            movement += -cameraRight * normalSpeed;

        if (direction.y > 0)
            movement += cameraForward * normalSpeed;
        else if (direction.y < 0)
            movement += -cameraForward * normalSpeed;
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
        movement = new Vector3(direction.x, 0, direction.y) * sprintSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position += movement * Time.fixedDeltaTime;
    }
}
