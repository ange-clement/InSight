using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport: Actionable
{
    public Vector3 position;
    public bool relative;

    public Transform objectToTeleport;

    public override void Activate()
    {
        if (relative)
        {
            objectToTeleport.position = transform.position + position;
        }
        else
        {
            objectToTeleport.position = position;
        }
    }

    public override void Deactivate()
    {

    }
}
