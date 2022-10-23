using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnEnable : MonoBehaviour
{
    public Actionable action;
    private void OnEnable()
    {
        action.Activate();
    }
}
