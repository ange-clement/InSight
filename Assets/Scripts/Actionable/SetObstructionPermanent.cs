using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObstructionPermanent : Actionable
{
    public ExpandObstruction ob;
    public override void Activate()
    {
        Debug.Log("AAAA");
        ob.isPermanent = true;
    }

    public override void Deactivate()
    {
    }
}
