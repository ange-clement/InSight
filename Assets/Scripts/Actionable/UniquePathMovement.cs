using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniquePathMovement : PathMovement
{
/*private Transform target;
private int currentTarget = 0;
private float currentDecelDist;

private float speed = 0f;

private Vector3 objectSpeed;*/

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
            currentTarget +=1;
                if (currentTarget == pathObject.childCount) Deactivate();
                else UpdateTarget();
        }
    }
}
}
