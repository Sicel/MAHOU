using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 lookOffset;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float sensitivity = 5.0f;
    [SerializeField] private float height = 5.0f;
    [SerializeField] private float distanceFromPlayer = 10.0f;

    private float rotateAmount;
    private Vector3 PlayerPos { get { return player.transform.position; } }

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(PlayerPos.x, PlayerPos.y + height, PlayerPos.z + distanceFromPlayer);
        transform.LookAt(PlayerPos + lookOffset);
    }

    // Update is called once per frame
    void Update()
    {
        //offset = new Vector3(PlayerPos.x, PlayerPos.y + height, PlayerPos.z + distanceFromPlayer);
    }

    public void RotateCamera(InputAction.CallbackContext context)
    {
        rotateAmount = context.ReadValue<Vector2>().x;
    }

    private void LateUpdate()
    {
        offset = Quaternion.AngleAxis(rotateAmount * sensitivity, Vector3.up) * offset;
        transform.LookAt(PlayerPos + lookOffset);
        transform.position = PlayerPos + offset;

    }
}
