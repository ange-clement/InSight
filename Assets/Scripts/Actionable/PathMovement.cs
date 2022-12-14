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

    public PlayEffects pickupEffects;
    public PlayEffects movingEffects;


    protected Transform target;
    protected int currentTarget = 0;
    protected float currentDecelDist;

    protected float speed = 0f;

    public Vector3 ObjectSpeed { get => objectSpeed; }
    protected Vector3 objectSpeed;

    public override void Activate()
    {
        base.Activate();
        if (movingEffects != null)
            movingEffects.Activate();
        isActivated = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        if (movingEffects != null)
            movingEffects.Deactivate();
        isActivated = false;
        objectSpeed = Vector3.zero;
    }

    protected void UpdateTarget()
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

                if (movingEffects != null)
                    movingEffects.setVolume(speed / maxSpeed);
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


    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().SetExternalObject(this);
        }
        else if (other.CompareTag("EntityTarget"))
        {
            if (pickupEffects != null)
                pickupEffects.Activate();
            other.GetComponent<EntityTarget>().controller.SetTargetParent(transform, Vector3.up);
        }
    }

    protected void OnTriggerExit(Collider other)
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
