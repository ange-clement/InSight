using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionEmitter : MonoBehaviour
{
    [HideInInspector] public Camera attachedCamera;

    private void Start()
    {
        attachedCamera = GetComponent<Camera>();
    }
}
