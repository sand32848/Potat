using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] string serial;
    [SerializeField] bool achieved;
    GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.GetComponent<BoxCollider>().enabled = false;
            achieved = true;
            gameHandler.updateCheckpoint(serial);
        }
    }
}
