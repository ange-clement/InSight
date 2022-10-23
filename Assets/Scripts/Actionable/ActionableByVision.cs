using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionableByVision: Actionable
{
    public Collider attachedCollider;
    public MeshFilter attachedMeshFilter;

    public float visionCheckFactor = 1.0f;
    public bool blocksVision = false;
    public bool forceSeen = false;

    private void Start()
    {
        attachedCollider   = GetComponent<Collider>();
        attachedMeshFilter = GetComponent<MeshFilter>();
    }
}
