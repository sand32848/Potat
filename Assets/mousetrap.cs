using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousetrap : MonoBehaviour
{
    [SerializeField] Damagezone damagezone;
    [SerializeField] Animator animator;
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
            resetmousetrap();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "player")
        {
            damagezone.enabled = true;
            animator.Play("Activate");
        }
    }

    public void resetmousetrap()
    {
        damagezone.enabled = false;
        animator.Play("reset");
    }
}
