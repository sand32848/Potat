using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenRaycast : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)&& !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit))
            {
                if(hit.transform.TryGetComponent(out RayReciever reciever))
                {
                    reciever.invokeEvent();
                }
            }
        }
    }
}
