using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;

    private bool isPaused = false;

    private void Update()
    {
        print(InputController.Instance.ESC);

        if (InputController.Instance.ESC)
        {

            if (isPaused)
            {
                unPause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void unPause()
    {
        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseCanvas.SetActive(false);
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        pauseCanvas.SetActive(true);
    }

}
