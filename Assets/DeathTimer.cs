using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float rayRange;
    private float _timer;
    [SerializeField]private LayerMask layerMask;
    GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        _timer = timer;
        gameHandler = GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down ,out hit,rayRange, layerMask))
        {
            timer = _timer;

          
        }
        else
        {
            timer -= Time.deltaTime;
       
        }

        if(timer <= 0)
        {
            death();
            timer = _timer;
        }
    }

    public void death()
    {
        gameHandler.callplayerdead();
      
    }
}
