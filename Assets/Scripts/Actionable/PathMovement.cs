using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : Actionable
{
    public Transform pathObject;

    public float maxSpeed = 2.0f;
    public float minSpeed = 0.2f;
    public float decelDist = 2.0f;
    public float acceleration = 4.0f;
    public float maxDegreesDelta = 180f;
    public bool isActivated = false;


    private Transform target;
    private int currentTarget = 0;
    private float currentDecelDist;

    private float speed = 0f;

    public Vector3 ObjectSpeed { get => objectSpeed; }
    private Vector3 objectSpeed;

    public override void Activate()
    {
        isActivated = true;
    }

    public override void Deactivate()
    {
        isActivated = false;
        objectSpeed = Vector3.zero;
    }

    private void UpdateTarget()
    {
        speed = minSpeed;

        target = pathObject.GetChild(currentTarget);
        if (target == null)
        {
            Debug.Log("Error : path object is empty!");
        }

        float d = Vector3.Distance(transform.position, target.position);
        if (d < 2.0f*decelDist)
        {
            currentDecelDist = d * 0.5f;
        }
        else
        {
            currentDecelDist = decelDist;
        }
    }


    void Update()
    {
        if (isActivated)
        {
            if (target == null)
            {
                UpdateTarget();
            }

            Vector3 direction = target.position - transform.position;
            float magnitude = direction.magnitude;
            float rotationAngle = Vector3.Angle(transform.forward, target.forward);
            bool pass = true;
            if (magnitude > 0.05f)
            {
                if (magnitude > currentDecelDist)
                {
                    if (speed < maxSpeed)
                    {
                        speed += acceleration * Time.deltaTime;
                    }
                }
                else
                {
                    speed -= acceleration * Time.deltaTime;
                    if (speed < minSpeed)
                    {
                        speed = minSpeed;
                    }
                }

                objectSpeed = direction / magnitude * speed;
                transform.position += objectSpeed * Time.deltaTime;

                pass = false;
            }
            if (rotationAngle > 5f)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, maxDegreesDelta * Time.deltaTime);
                pass = false;
            }
            if (pass)
            {
                currentTarget = (currentTarget + 1) % pathObject.childCount;
                UpdateTarget();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().SetExternalObject(this);
        }
        else if (other.CompareTag("EntityTarget"))
        {
            other.GetComponent<EntityTarget>().controller.SetTargetParent(transform, Vector3.up);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().RemoveExternalObject();
        }
        else if (other.CompareTag("EntityTarget"))
        {
            other.GetComponent<EntityTarget>().controller.ResetTargetParent();
        }
    }
}
