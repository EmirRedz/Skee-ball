using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Transition")]
    public Animator transitionAnimator;
    public float transitionTime;

    [Header("Play Button")]
    public MenuCameraSwitcher cameraSwitcher;
    public GameObject chooseCamera;

    private void Awake()
    {
        if (chooseCamera != null)
        {
            chooseCamera.SetActive(false);
        }
    }

    public void PlayButton()
    {
        cameraSwitcher.cameras[Mathf.RoundToInt(cameraSwitcher.currentCamera)].SetActive(false);
        chooseCamera.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string levelName)
    {
        StartCoroutine(LoadLevel(levelName));
    }

    IEnumerator LoadLevel(string levelName)
    {
        transitionAnimator.SetTrigger("transition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelName);


    }
}
