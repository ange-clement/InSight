using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEntity : ActionableByVision
{
    public EntityController controller;
    public PlayEffects effect;

    private void Start()
    {
        if (controller == null)
            controller = transform.parent.GetComponent<EntityController>();
    }
    public override void Activate()
    {

    }

    public override void Deactivate()
    {
        if (effect != null && controller.wasDraged)
        {
            effect.transform.position = transform.position;
            effect.Activate();
        }

        transform.rotation = Quaternion.identity;
        transform.position = controller.generator.position;
        controller.target.position = controller.generator.position;
        //controller.rb.ResetInertiaTensor();
        controller.rb.velocity = Vector3.zero;
        controller.rb.angularVelocity = Vector3.zero;

        controller.ResetTargetParent();
    }
}
