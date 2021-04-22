using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMotion : MonoBehaviour
{
    private float _speed;
    private float _angularSpeed = 0.7f;
    private float _rotationAngle;
    private CharacterController _characterController;
    private float _minX,_minZ,_maxX,_maxZ;

    void Start()
    {
        _speed = 0f;
        _rotationAngle = 0f;
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.W))
            _speed += 0.05f;
        else if (Input.GetKey(KeyCode.S))
            _speed -= 0.05f;

        _rotationAngle = mouse_x * _angularSpeed *Time.deltaTime;
        transform.Rotate(0,_rotationAngle, 0);
        Vector3 point = Vector3.forward * Time.deltaTime * _speed;
        if (transform.position.x <= _minX || transform.position.x >= _maxX || transform.position.z <= _minZ ||
           transform.position.z >= _maxZ) point.y = 0;
        else
        {
            Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
            point.y = 1.6f+Terrain.activeTerrain.SampleHeight(pos)-transform.position.y; // delta in Y direction
         }

        Vector3 direction = transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);
        _characterController.Move(direction);
    }
}