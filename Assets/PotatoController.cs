using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float flipSpeed;
    [SerializeField] private float camLookSpeed;
    [SerializeField] private GameObject ballTracker;
    [SerializeField] private GameObject parent ;

    [SerializeField] private GameObject posRight;
    [SerializeField] private GameObject posLeft;

    private GameObject gimball => GameObject.FindGameObjectWithTag("Gimball");

    private GameObject cam => Camera.main.gameObject;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void FixedUpdate()
    {
        Vector3 targetDirection = new Vector3(ballTracker.transform.position.x, transform.position.y, ballTracker.transform.position.z) - rb.transform.position;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, camLookSpeed, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        rb.AddForce(cam.transform.forward * InputController.Instance.movement.y * moveSpeed);

        if (InputController.Instance.movement.x == 1)
        {
            rb.AddForceAtPosition(Vector3.up * -flipSpeed, posRight.transform.position);
        }
        else if (InputController.Instance.movement.x == -1)
        {
            rb.AddForceAtPosition(Vector3.up * -flipSpeed, posLeft.transform.position);
        }



        if (InputController.Instance.movement.y != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, gimball.transform.rotation, Time.deltaTime * camLookSpeed);
        }   


    }
}
