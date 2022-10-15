using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraControl : MonoBehaviour
{
    public bool hasControl;
    public Image pointer;

    private PlayerMovement playerMovement;
    private PlayerCamera playerCamera;
    private PlayerGrab playerGrab;
    private Color pointerColor;

    void Start()
    {
        hasControl = true;
        playerMovement = GetComponent<PlayerMovement>();
        playerCamera   = GetComponent<PlayerCamera>();
        playerGrab     = GetComponent<PlayerGrab>();
    }

    public void GiveControl()
    {
        hasControl = false;
        playerMovement.enabled = false;
        playerCamera.enabled   = false;
        playerGrab.enabled     = false;
        pointerColor = pointer.color;
        pointer.color = new Color(0, 0, 0, 0);
    }

    public void TakeControl()
    {
        hasControl = true;
        playerMovement.enabled = true;
        playerCamera.enabled   = true;
        playerGrab.enabled     = true;
        pointer.color = pointerColor;
    }
}
