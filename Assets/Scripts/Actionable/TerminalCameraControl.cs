using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalCameraControl : ActionableByPlayerClic
{
    public Camera attachedCamera;
    public Transform cameraModel;
    public TriggerOnTag checkPlayer;

    public float sens = 200f;
    public float yRotationLimit = 80f;


    private PlayerCameraControl playerCameraControl;
    private bool hasControl;

    private Vector2 rotation = Vector2.zero;

    private void Start()
    {
        hasControl = false;
        playerCameraControl = FindObjectOfType<PlayerCameraControl>();
        rotation.x = cameraModel.transform.eulerAngles.y;
        rotation.y = cameraModel.transform.eulerAngles.x;
        if (rotation.y > 180)
        {
            rotation.y = rotation.y - 360;
        }
        Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
    }

    public override void Activate()
    {
        if (checkPlayer.isIn)
        {
            hasControl = true;
            playerCameraControl.GiveControl();
        }
    }

    public override void Deactivate()
    {
        hasControl = false;
        playerCameraControl.TakeControl();
    }

    private void Update()
    {
        if (hasControl)
        {
            rotation.x += Input.GetAxis("Mouse X") * sens * Time.deltaTime;
            rotation.y -= Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
            rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

            cameraModel.transform.rotation = Quaternion.AngleAxis(rotation.x, Vector3.up) * Quaternion.AngleAxis(rotation.y, Vector3.right);

            if (Input.GetButtonDown("Fire1"))
            {
                Deactivate();
            }
        }
    }
}
