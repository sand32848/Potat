using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsmatSwitcher : MonoBehaviour
{
    [SerializeField] PhysicMaterial Normal;
    [SerializeField] PhysicMaterial Bounce;
    [SerializeField] PhysicMaterial LowFric;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Switchmat(int code)
    {
        switch (code)
        {
            case 3:
                GetComponent<Collider>().material = LowFric;
                break;
            case 2:
                GetComponent<Collider>().material = Bounce;
                break;
            case 1:
                GetComponent<Collider>().material = Normal;
                break;
        }
    }
}
