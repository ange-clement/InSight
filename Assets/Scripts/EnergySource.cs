using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySource : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        ActionableByEnergy action = collision.gameObject.GetComponent<ActionableByEnergy>();
        if (action != null)
        {
            action.Activate();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ActionableByEnergy action = collision.gameObject.GetComponent<ActionableByEnergy>();
        if (action != null)
        {
            action.Deactivate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ActionableByEnergy action = other.gameObject.GetComponent<ActionableByEnergy>();
        if (action != null)
        {
            action.Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ActionableByEnergy action = other.gameObject.GetComponent<ActionableByEnergy>();
        if (action != null)
        {
            action.Deactivate();
        }
    }
}
