using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogTrigger : MonoBehaviour
{
    [SerializeField] Animator anim;
    GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandler._isdead)
        {
            resetdog();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            anim.Play("dog");
        }
    }

    public void resetdog()
    {
        anim.Play("reset");
    }
}
