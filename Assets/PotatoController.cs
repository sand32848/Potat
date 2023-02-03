using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float rotateForce;
    [SerializeField] private GameObject camera;
    private float cameraTorque;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddTorque(new Vector3(InputController.Instance.movement.x, 0, InputController.Instance.movement.y) * rotateForce);
    }
}
