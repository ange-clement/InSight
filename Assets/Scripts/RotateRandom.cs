using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandom : MonoBehaviour
{
    public Transform rot;
    public Transform rotAxis;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot.RotateAround(transform.position, Vector3.forward, speed * Time.deltaTime);
        transform.Rotate((rotAxis.position - transform.position).normalized, speed * Time.deltaTime);
    }
}
