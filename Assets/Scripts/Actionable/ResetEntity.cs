using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetEntity : ActionableByVision
{
    public EntityController controller;
    public PlayParticleAndSound effect;

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
        if (effect != null && !effect.isPlaying() && Vector3.SqrMagnitude(transform.position - controller.transform.position) > 1.0f)
        {
            if (Vector3.SqrMagnitude(transform.position - effect.transform.position) > 1.0f)
            {
                effect.Activate();
            }
            effect.transform.position = transform.position;
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
