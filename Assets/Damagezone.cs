using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagezone : MonoBehaviour
{
    [SerializeField] int Damagecode;
    GameHandler gameHandler;
    Audioclipholder audioclipholder;
    private void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>();
        audioclipholder = FindObjectOfType<Audioclipholder>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            audioclipholder.callaudio(Damagecode);
            gameHandler.callplayerdead();
            
        }
        else if(collision.transform.tag == "Weak")
        {
            audioclipholder.callaudio(0);
            Destroy(collision.gameObject);
             
        }
    }
}
