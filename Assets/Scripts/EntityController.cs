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

    [HideInInspector] public Rigidbody rb;

    [HideInInspector] public bool isGrabed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = entity.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (followWhenReleased || isGrabed)
        {
            Vector3 direction = target.position - entity.transform.position;
            float magnitude = direction.sqrMagnitude;
            if (magnitude > 0.05f)
            {
                rb.AddForce(direction.normalized * Mathf.Clamp((magnitude+1.0f) * 2.0f, 0, maxForce), ForceMode.Acceleration);
            }
        }
    }

    public void OnCameraOut()
    {
        entity.transform.rotation = Quaternion.identity;
        entity.transform.position = generator.position;
        target.position = generator.position;
        rb.ResetInertiaTensor();
        rb.velocity = Vector3.zero;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EntityTrigger"))
        {
            other.GetComponentInParent<EventManager>().Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EntityTrigger"))
        {
            other.GetComponentInParent<EventManager>().Disactivate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            transform.Translate(Vector3.up);
        }
    }*/
}
