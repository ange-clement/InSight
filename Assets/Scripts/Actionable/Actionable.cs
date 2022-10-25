using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actionable: MonoBehaviour
{
    public PlayEffects effectActivate;
    public PlayEffects effectDeactivate;

    public virtual void Activate()
    {
        if (effectActivate != null)
            effectActivate.Activate();
        if (effectDeactivate != null)
            effectDeactivate.Deactivate();
    }
    public virtual void Deactivate()
    {
        if (effectActivate != null)
            effectActivate.Deactivate();
        if (effectDeactivate != null)
            effectDeactivate.Activate();
    }
}
