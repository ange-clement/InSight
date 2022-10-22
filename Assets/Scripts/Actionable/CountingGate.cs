using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountingGate : Actionable
{
    public int nbActivate = 0;
    public int nbToActivate = 2;

    public Actionable[] events;
    public Actionable[] invertedEvents;
    public override void Activate()
    {
        nbActivate++;
        if (nbActivate == nbToActivate)
        {
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

    public override void Deactivate()
    {
        nbActivate--;
        if (nbActivate == nbToActivate)
        {
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
}
