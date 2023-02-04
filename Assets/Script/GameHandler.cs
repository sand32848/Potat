using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] bool isdead;

    [SerializeField] checkpoint[] mycheckpoint;
    [SerializeField] Transform player;

    [System.Serializable]
    public class checkpoint
    {
        public string serial;
        public Checkpoint chekpoint;
        public Transform respawn;
        public bool isactive;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead)
        {
            isdead = false;
            for (int i = 0; i < mycheckpoint.Length; i++)
            {
                if (mycheckpoint[i].isactive)
                {
                    Debug.Log("stuck?");
                    player.transform.position = mycheckpoint[i].respawn.position;
                    break;
                }
            }
        }
    }

    public void callplayerdead()
    {
        isdead = true;
    }

    public void updateCheckpoint(string serials)
    {
        for(int i = 0; i < mycheckpoint.Length; i++)
        {
            if(serials == mycheckpoint[i].serial)
            {
                mycheckpoint[i].isactive = true;
            }
            else
            {
                mycheckpoint[i].isactive = false;
            }
        }
    }
}
