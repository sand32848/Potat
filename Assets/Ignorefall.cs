using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignorefall : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<DeathTimer>().ignoredead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<DeathTimer>().ignoredead = true;
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<DeathTimer>().ignoredead = false;
    }
}
