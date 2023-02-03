using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject camera;
    [SerializeField] private Transform playerTransform;

    private Vector3 _cameraOffset;
    [SerializeField]private float smoothFactor = 0.5f;
    [SerializeField] private float rotationSpeed = 5.0f;
    

    void Start()
    {
        _cameraOffset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        print(InputController.Instance.MouseInput);

        Quaternion camTurnAngle = Quaternion.AngleAxis(InputController.Instance.MouseInput.x * rotationSpeed, Vector3.up);

        _cameraOffset = camTurnAngle * _cameraOffset;

        Vector3 newPos = playerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }
    
}
