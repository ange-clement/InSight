using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sens = 200f;
    public float yRotationLimit = 80f;
    public Camera playerCamera;

    private Vector2 rotation = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        rotation.x += Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        rotation.y -= Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

        transform.localRotation = Quaternion.AngleAxis(rotation.x, Vector3.up);
        playerCamera.transform.localRotation = Quaternion.AngleAxis(rotation.y, Vector3.right);
    }
}
