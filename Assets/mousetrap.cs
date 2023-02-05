using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousetrap : MonoBehaviour
{
    [SerializeField] BoxCollider damagezone;
    [SerializeField] Animator animator;
    GameHandler gameHandler;
    Audioclipholder audioclipholder;
    bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>();
        audioclipholder = FindObjectOfType<Audioclipholder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandler._isdead)
        {
            resetmousetrap();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (!triggered)
            {
                triggered = true;
                damagezone.enabled = true;
                audioclipholder.callaudio(3);
                animator.Play("Activate");
            }
            
        }
    }

    public void resetmousetrap()
    {
        triggered = false;
        damagezone.enabled = false;
        animator.Play("reset");
    }

    public void onendmousetrap()
    {
        damagezone.enabled = false;
    }
}
