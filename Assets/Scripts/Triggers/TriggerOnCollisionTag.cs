using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnCollisionTag : MonoBehaviour
{
    public string tagToTrigger;
    public bool callsDeactivate = true;

    public Actionable[] events;
    public Actionable[] invertedEvents;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(tagToTrigger))
        {
            foreach (Actionable action in events)
            {
                action.Activate();
            }
            foreach (Actionable action in invertedEvents)
            {
                action.Deactivate();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (callsDeactivate && collision.collider.CompareTag(tagToTrigger))
        {
            foreach (Actionable action in events)
            {
                action.Deactivate();
            }
            foreach (Actionable action in invertedEvents)
            {
                action.Activate();
            }
        }
    }
}
