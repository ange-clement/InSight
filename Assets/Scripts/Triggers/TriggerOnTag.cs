using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnTag : MonoBehaviour
{
    public string tagToTrigger;
    public bool callsDeactivate = true;
    [HideInInspector] public bool isIn = false;

    public Actionable[] events;
    public Actionable[] invertedEvents;

    private void ActivateAllIfTag(string tag)
    {
        if (tag.Equals(tagToTrigger))
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
        isIn = true;
    }

    private void DeactivateAllIfTag(string tag)
    {
        if (callsDeactivate && tag.Equals(tagToTrigger))
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
        isIn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivateAllIfTag(other.tag);
    }
    private void OnCollisionEnter(Collision collision)
    {
        ActivateAllIfTag(collision.collider.tag);
    }

    private void OnTriggerExit(Collider other)
    {
        DeactivateAllIfTag(other.tag);
    }

    private void OnCollisionExit(Collision collision)
    {
        DeactivateAllIfTag(collision.collider.tag);
    }
}
