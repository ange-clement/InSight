using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public float maxForce = 40f;

    public Transform entity;
    public Transform target;
    public Transform generator;
    public float targetOffset;

    public bool followWhenReleased = true;
    public float dragWhenGrabbed = 5.0f;

    public bool wasDraged = false;

    private float dragWhenReleased;

    [HideInInspector] public Rigidbody rb;

    private bool isGrabed = false;
    public bool IsGrabed
    {
        get
        {
            return isGrabed;
        }

        set
        {
            isGrabed = value;
            if (isGrabed)
            {
                rb.drag = dragWhenGrabbed;
                wasDraged = true;
            }
            else
            {
                rb.drag = dragWhenReleased;
            }
        }
    }

    void Start()
    {
        rb = entity.GetComponent<Rigidbody>();
        dragWhenReleased = rb.drag;
    }

    void Update()
    {
        if (followWhenReleased || IsGrabed)
        {
            Vector3 direction = target.position - entity.transform.position;
            float magnitude = direction.sqrMagnitude;
            if (magnitude > 0.05f)
            {
                rb.AddForce(direction.normalized* Mathf.Clamp((magnitude+1.0f) * 2.0f, 0, maxForce), ForceMode.Acceleration);
            }
        }
    }

    public void SetTargetParent(Transform parent, Vector3 pos)
    {
        if (target.parent != parent)
        {
            target.parent = parent;
            target.localPosition = pos * targetOffset;
        }
    }

    public void SetTargetParent(Transform parent)
    {
        SetTargetParent(parent, parent.position);
    }

    public void ResetTargetParent()
    {
        if (target.parent != transform)
        {
            target.parent = transform;
        }
        wasDraged = false;
    }
}
