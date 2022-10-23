using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceEntitySeen : ActionableWithTrigger
{
    public override void Activate(GameObject collisionObject)
    {
        collisionObject.GetComponent<ActionableByVision>().forceSeen = true;
    }

    public override void Deactivate(GameObject collisionObject)
    {
        collisionObject.GetComponent<ActionableByVision>().forceSeen = false;
    }
}
