using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTimer : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private float rayRange;
    private float _timer;
    [SerializeField]private LayerMask layerMask;
    
    // Start is called before the first frame update
    void Start()
    {
        _timer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down ,out hit,rayRange, layerMask))
        {
            timer = _timer;

            print(hit.transform.gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
            print("count");
        }

        if(timer <= 0)
        {
            death();
        }
    }

    public void death()
    {
        print("Dead");
    }
}
