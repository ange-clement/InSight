using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float jumpSpeed = 8.0f;
    public float gravityValue = -20.0f;
    public float gravityMultiplier = 2.0f;

    public float terminalVelocity = -40.0f;

    public int nbFramesJump = 20;


    public Vector3 playerVelocity;
    private bool groundedPlayer;
    private CharacterController controller;

    private float currentGravity;
    private PathMovement moovingObject = null;

    private int framesSincePlayerJumped;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        framesSincePlayerJumped = 0;
        currentGravity = gravityValue * gravityMultiplier;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;



        Vector3 externalVelocity = Vector3.zero;
        if (moovingObject != null)
        {
            groundedPlayer = true;
            externalVelocity = moovingObject.ObjectSpeed;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * playerSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            framesSincePlayerJumped = -nbFramesJump;
        }
        playerVelocity.y += Mathf.Clamp01(((terminalVelocity - playerVelocity.y) / terminalVelocity)) * currentGravity * Time.deltaTime;
        if (framesSincePlayerJumped < 0 && groundedPlayer)
        {
            currentGravity = gravityValue;
            playerVelocity.y += jumpSpeed;
            RemoveExternalObject();
        }
        if (groundedPlayer)
        {
            if (playerVelocity.y < 0)
            {
                playerVelocity.y = 0;
            }

            playerVelocity.x = playerVelocity.x * 0.5f;
            playerVelocity.z = playerVelocity.z * 0.5f;
        }
        if (Input.GetButtonUp("Jump") || playerVelocity.y < 0)
        {
            currentGravity = gravityValue * gravityMultiplier;
        }

        controller.Move((transform.TransformDirection(move) + playerVelocity + externalVelocity) * Time.deltaTime);

        framesSincePlayerJumped++;
    }

    public void SetExternalObject(PathMovement externalObject)
    {
        moovingObject = externalObject;
    }

    public void RemoveExternalObject()
    {
        if (moovingObject != null)
        {
            Vector3 objspeed = moovingObject.ObjectSpeed;
            playerVelocity += 1.8f * new Vector3(objspeed.x, 0f, objspeed.z);
            playerVelocity.y += Mathf.Max(0f, objspeed.y);
            moovingObject = null;
        }
    }
}
