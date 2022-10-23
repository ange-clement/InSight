using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateActionsTrigger : ActionableByEnergy
{
    public ActionableWithTrigger[] actions;
    public ActionableWithTrigger[] invertedActions;

    public int nbInZone = 0;
    public int activateNb = 1;

    public override void Activate(GameObject collisionObject)
    {
        nbInZone++;
        if (nbInZone == activateNb)
        {
            foreach (ActionableWithTrigger action in actions)
            {
                action.Activate(collisionObject);
            }
            foreach (ActionableWithTrigger action in invertedActions)
            {
                action.Deactivate(collisionObject);
            }
        }
    }

    public override void Deactivate(GameObject collisionObject)
    {
        nbInZone--;
        if (nbInZone != activateNb)
        {
            foreach (ActionableWithTrigger action in actions)
            {
                action.Deactivate(collisionObject);
            }
            foreach (ActionableWithTrigger action in invertedActions)
            {
                action.Activate(collisionObject);
            }
        }
    }
}
