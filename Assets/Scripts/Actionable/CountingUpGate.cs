using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingUpGate : Actionable
{
    public int nbActivate = 0;
    public int nbToActivate = 2;

    public Actionable[] events;
    public Actionable[] invertedEvents;

    public void CheckChange()
    {
        if (nbActivate >= nbToActivate)
        {
            base.Activate();
            foreach (Actionable eventManager in events)
            {
                eventManager.Activate();
            }
            foreach (Actionable eventManager in invertedEvents)
            {
                eventManager.Deactivate();
            }
        }
        else
        {
            base.Deactivate();
            foreach (Actionable eventManager in events)
            {
                eventManager.Deactivate();
            }
            foreach (Actionable eventManager in invertedEvents)
            {
                eventManager.Activate();
            }
        }
    }
    public override void Activate()
    {
        nbActivate++;
        CheckChange();
    }

    public override void Deactivate()
    {
        nbActivate--;
        CheckChange();
    }
}
