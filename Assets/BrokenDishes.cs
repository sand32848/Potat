using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenDishes : MonoBehaviour
{
    [SerializeField] GameObject[] shard;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shardupdate()
    {
        shard[count - 1].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "weak")
        {
            Destroy(other.gameObject);
            count += 1;
            shardupdate();
        }
    }
}
