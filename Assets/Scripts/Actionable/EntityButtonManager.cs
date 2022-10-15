using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityButtonManager : ActionableByEnergy
{
    public Actionable[] actions;
    public Actionable[] invertedActions;

    public int nbInZone = 0;
    public int activateNb = 1;

    public override void Activate()
    {
        nbInZone++;
        if (nbInZone == activateNb)
        {
            foreach (Actionable action in actions)
            {
                action.Activate();
            }
            foreach (Actionable action in invertedActions)
            {
                action.Deactivate();
            }
        }
    }

    public override void Deactivate()
    {
        nbInZone--;
        if (nbInZone != activateNb)
        {
            foreach (Actionable action in actions)
            {
                action.Deactivate();
            }
            foreach (Actionable action in invertedActions)
            {
                action.Activate();
            }
        }
    }
}
