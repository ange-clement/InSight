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
        transform.rotation = Quaternion.identity;
        transform.position = controller.generator.position;
        controller.target.position = controller.generator.position;
        controller.rb.ResetInertiaTensor();
        controller.rb.velocity = Vector3.zero;
    }
}
