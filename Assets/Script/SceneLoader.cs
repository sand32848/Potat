using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonClass<SceneLoader>
{
    private bool _transitioning = false;
    public bool transitioning => _transitioning;

    [SerializeField] private Animator _transition;
    [SerializeField] private GameObject _transitionImage;
    [SerializeField] private float _transitiontime;

    public delegate void OnSceneTransition();
    public static event OnSceneTransition sceneTransition;

    private void Awake()
    {
        SingletonClassCallOnAwake();
        _transitionImage.SetActive(true);
    }
    private void Update()
    {
        //DebugCommand();
    }
    public void startLoadLevel(int level)
    {
        StartCoroutine(loadlevel(level));
    }
    public void startRestartLevel(bool resetCP)
    {
        StartCoroutine(RestartLevel(resetCP));
    }
    public void loadNextLevel()
    {
        StartCoroutine(NextLevel());
    }
    public void exitToDestop()
    {
        StartCoroutine(exitGame());
    }
    IEnumerator loadlevel(int levelindex)
    {

        Time.timeScale = 1;

        _transition.SetTrigger("FadeOut");

        yield return new WaitForSeconds(_transitiontime);

        DOTween.KillAll();

        SceneManager.LoadScene(levelindex);
    }
    IEnumerator RestartLevel(bool resetCP)
    {

        int levelIndex = SceneManager.GetActiveScene().buildIndex;

        Time.timeScale = 1;

        _transition.SetTrigger("FadeOut");

        yield return new WaitForSeconds(_transitiontime);

        DOTween.KillAll();

        SceneManager.LoadScene(levelIndex);
    }
    IEnumerator NextLevel()
    {

        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        levelIndex++;

        if (levelIndex > (SceneManager.sceneCountInBuildSettings-1)) levelIndex = 0;

        Time.timeScale = 1;

        _transition.SetTrigger("FadeOut");

        yield return new WaitForSeconds(_transitiontime);

        DOTween.KillAll();

        SceneManager.LoadScene(levelIndex);
    }
    IEnumerator exitGame()
    {
        Time.timeScale = 1;

        _transition.SetTrigger("FadeOut");

        yield return new WaitForSeconds(_transitiontime);

        Application.Quit();

    }

    public void PlaySceneLocationTransition()
    {
        Time.timeScale = 1;

        _transition.SetTrigger("FadeOutIn");

    }
    public void TransitioningBegin()
    {
        _transitioning = true;
        sceneTransition?.Invoke();
    }
    public void TransitioningEnd()
    {
        _transitioning = false;
        sceneTransition?.Invoke();
    }

    /*public void DebugCommand()
    {
        DebugNextScene();
        DebugRestartScene();
    }
    public void DebugNextScene()
    {
        if (InputController.Instance.F12 == true)
        {
            loadNextLevel();
        }
    }
    public void DebugRestartScene()
    {
        if (InputController.Instance.F11 == true)
        {
            startRestartLevel(true);
        }
    }*/
}
