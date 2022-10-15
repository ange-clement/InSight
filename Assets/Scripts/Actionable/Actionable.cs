using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actionable: MonoBehaviour
{
    public abstract void Activate();
    public abstract void Deactivate();
}
