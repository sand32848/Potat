using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadmenu : MonoBehaviour
{
    [SerializeField] SceneLoader loader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadMmenu()
    {
        loader.startLoadLevel(0);
    }
}
