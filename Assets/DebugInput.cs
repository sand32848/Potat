using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    GameHandler gameHandler;
    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindGameObjectWithTag("Handler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputController.Instance.R)
        {
            gameHandler.callplayerdead();
        }

        int i = InputController.Instance.GetPressedNumber();
        switch (i)
        {
            case 1:
                gameHandler.updateCheckpoint("0");
                gameHandler.callplayerdead();
                break;
            case 2:
                gameHandler.updateCheckpoint("1");
                gameHandler.callplayerdead();
                break;
            case 3:
                gameHandler.updateCheckpoint("2");
                gameHandler.callplayerdead();
                break;
            case 4:
                gameHandler.updateCheckpoint("3");
                gameHandler.callplayerdead();
                break;
        }
            
        
    }
}
