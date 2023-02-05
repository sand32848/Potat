using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallXray : MonoBehaviour
{
    //[SerializeField] private List<GameObject> currentlyInTheWay;
    //[SerializeField] private List<GameObject> alreadyTransparent;
    
    private GameObject player => GameObject.FindGameObjectWithTag("Player");
    private Renderer currentRenderer;

    [SerializeField]private LayerMask layer;
    void Update()
    {

        RaycastHit raycastHit;

        if (Physics.Linecast(transform.position, player.transform.position, out raycastHit, layer))
        {
            if (raycastHit.transform.tag == "Wall")
            {
                if (raycastHit.transform.TryGetComponent(out Renderer renderer))
                {
                    currentRenderer = renderer;
                    currentRenderer.enabled = false;
                }
            }


            if (!currentRenderer) return;
           if(currentRenderer.transform.gameObject != raycastHit.transform.gameObject)
            {
                currentRenderer.enabled = true;
                currentRenderer = null;
            }
        }
        else
        {
            if (currentRenderer) currentRenderer.enabled = true;
        }
    }

    private void GetAllObjectsInTheWay()
    {

    }

    private void MakeObjectsTransparent()
    {

    }

    private void MakeObjectSolid()
    {

    }
}
