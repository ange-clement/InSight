using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndBack : Actionable
{
    public Transform objectToMove;
    public float speed = 10f;
    public Vector3 restPos = Vector3.zero;
    public Vector3 activatedPos = new Vector3(0f, 0.95f, 0f);


    public bool open = false;
    public override void Activate()
    {
        open = true;
    }
    public override void Deactivate()
    {
        open = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            objectToMove.localPosition = Vector3.Lerp(objectToMove.localPosition, activatedPos, speed * Time.deltaTime);
        }
        else
        {
            objectToMove.localPosition = Vector3.Lerp(objectToMove.localPosition, restPos, speed * Time.deltaTime);
        }
    }
}
