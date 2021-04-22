using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherCameraMotion : MonoBehaviour
{
    float angularSpeed;

    void Start()
    {
        angularSpeed = 5.0f;
    }

    void Update()
    {
        transform.Rotate(0,Input.GetAxis("Mouse X")*angularSpeed, 0);
    }
}