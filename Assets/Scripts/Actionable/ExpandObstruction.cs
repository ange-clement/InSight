using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandObstruction : ActionableByVision
{
    public float expandSpeed = 2.0f;

    public bool isPermanent = false;

    private float startExpensionTime = -1;
    private Vector3 defaultScale;
    private bool isSeen = false;
    void Start()
    {
        defaultScale = transform.localScale;
    }

    void Update()
    {
        if (startExpensionTime > 0)
        {
            float expandAmount = (Time.time - startExpensionTime) * expandSpeed;
            transform.localScale = defaultScale + Vector3.one * expandAmount * expandAmount;

            base.effectActivate.setVolume(expandAmount * 0.5f);
        }
    }

    public override void Activate()
    {
        if (!isSeen)
        {
            isSeen = true;
            startExpensionTime = Time.time;
            base.Activate();
        }
    }

    public override void Deactivate()
    {
        if (!isPermanent && isSeen)
        {
            isSeen = false;
            startExpensionTime = -1;
            transform.localScale = defaultScale;

            base.Deactivate();
        }
    }
}
