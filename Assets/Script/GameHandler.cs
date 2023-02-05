using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameHandler : MonoBehaviour
{
    [SerializeField] bool isdead;
    public bool _isdead => isdead;
    [SerializeField] checkpoint[] mycheckpoint;
    [SerializeField] Transform player;
    [SerializeField] Animator winscene;
    [SerializeField] GameObject ending;

    [SerializeField] CanvasGroup sceneTransitionCanvas;

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
                    player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
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

    IEnumerator showWin()
    {
        Tween myTween = sceneTransitionCanvas.DOFade(1, 0.75f);

        yield return myTween.WaitForCompletion();

        ending.SetActive(true);

        Tween myTween2 = sceneTransitionCanvas.DOFade(0, 0.5f);

        yield return myTween2.WaitForCompletion();

        winscene.Play("ending");
    }

    public void win()
    {

        StartCoroutine(showWin());
    
    }
}
