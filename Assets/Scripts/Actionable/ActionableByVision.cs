using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionableByVision: Actionable
{
    public Collider attachedCollider;
    public MeshFilter attachedMeshFilter;
    public bool blocksVision = false;

    private void Start()
    {
        attachedCollider   = GetComponent<Collider>();
        attachedMeshFilter = GetComponent<MeshFilter>();
    }
}
