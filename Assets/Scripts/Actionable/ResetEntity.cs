using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEntity : ActionableByVision
{
    private EntityController controller;

    private void Start()
    {
        controller = transform.parent.GetComponent<EntityController>();
    }
    public override void Activate()
    {

    }

    public override void Deactivate()
    {
        controller.OnCameraOut();
    }
}
