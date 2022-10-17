using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnTag : MonoBehaviour
{
    public string tagToTrigger;
    public bool callsDeactivate = true;

    public Actionable[] events;
    public Actionable[] invertedEvents;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagToTrigger))
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

    private void OnTriggerExit(Collider other)
    {
        if (callsDeactivate && other.CompareTag(tagToTrigger))
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
