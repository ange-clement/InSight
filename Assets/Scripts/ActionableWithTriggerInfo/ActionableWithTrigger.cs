using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionableWithTrigger : MonoBehaviour
{
    public abstract void Activate(GameObject collisionObject);
    public abstract void Deactivate(GameObject collisionObject);
}

