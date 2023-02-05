using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousetrapend : MonoBehaviour
{
    [SerializeField] mousetrap mt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onendmousetrap()
    {
        mt.onendmousetrap();
    }
}
