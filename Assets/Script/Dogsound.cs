using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogsound : MonoBehaviour
{
    Audioclipholder audioclipholder;

    // Start is called before the first frame update
    void Start()
    {
        audioclipholder = FindObjectOfType<Audioclipholder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bark()
    {
        audioclipholder.callaudio(6);
    }
}
