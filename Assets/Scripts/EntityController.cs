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
            }
            else
            {
                rb.drag = dragWhenReleased;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = entity.GetComponent<Rigidbody>();
        dragWhenReleased = rb.drag;
    }

    // Update is called once per frame
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
}
