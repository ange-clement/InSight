using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : Actionable
{
    public Transform pathObject;

    public float speed = 2.0f;
    public bool isActivated = false;


    private Transform target;
    private Vector3 previousTargetPos;
    private int currentTarget = 0;

    private Vector3 objectSpeed;
    public float t;
    public float dt = 0f;
    public float ddt = 0f;


    public override void Activate()
    {
        isActivated = true;
    }

    public override void Deactivate()
    {
        isActivated = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void UpdateTarget()
    {
        t = 0f;
        dt = 0f;
        objectSpeed = Vector3.zero;
        previousTargetPos = transform.position;
        target = pathObject.GetChild(currentTarget);
        if (target == null)
        {
            Debug.Log("Error : path object is empty!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActivated)
        {
            if (target == null)
            {
                UpdateTarget();
            }

            if (t < 0.5)
            {
                ddt = 1f;
            }
            else
            {
                ddt = -1f;
            }

            Vector3 direction = target.position - transform.position;
            float magnitude = direction.sqrMagnitude;
            if (magnitude > 0.05f)
            {
                //objectSpeed += direction.normalized * Mathf.Clamp((magnitude + 1.0f) * 2.0f, 0, speed);
                //transform.Translate(objectSpeed * Time.deltaTime);

                //transform.position = Vector3.SmoothDamp(transform.position, target.position, ref objectSpeed, speed);

                //transform.position = Vector3.MoveTowards(transform.position, target.position, 1.0f);

                transform.position = Vector3.Lerp(previousTargetPos, target.position, t);
                t += dt * Time.deltaTime;
                if (dt < speed)
                {
                    dt += ddt * Time.deltaTime;
                }
                else
                {
                    dt = speed;
                }
            }
            else {
                currentTarget = (currentTarget + 1) % pathObject.childCount;
                UpdateTarget();
            }
        }
    }
}
