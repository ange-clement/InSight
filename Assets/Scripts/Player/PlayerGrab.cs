using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGrab : MonoBehaviour
{
    public Transform playerCamera;
    public Image pointer;
    public Color pointerColor;
    public Color grabingColor;

    private EntityController entity;
    private bool drag = false;
    private int ignoreEntityLayerMask = ~(1 << 6 | 1 << 2);

    private PlayerCameraControl playerCameraControl;

    private void Start()
    {
        pointer.color = pointerColor;
        playerCameraControl = GetComponent<PlayerCameraControl>();
    }

    void Update()
    {
        // Move behaviour
        if (Input.GetButtonDown("Fire1") && !drag)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit))
            {
                if (hit.collider.CompareTag("Entity"))
                {
                    entity = hit.collider.transform.parent.GetComponent<EntityController>();
                    entity.isGrabed = true;
                    drag = true;

                    pointer.color = grabingColor;
                }
                else if (hit.collider.CompareTag("Camera"))
                {
                    hit.transform.SendMessage("Activate");
                }
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            if (entity != null)
            {
                entity.isGrabed = false;
            }
            drag = false;

            pointer.color = pointerColor;
        }

        if (drag)
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, 1000f, ignoreEntityLayerMask))
            {
                entity.target.transform.position = hit.point + hit.normal * entity.targetOffset;
            }
        }
    }
}
