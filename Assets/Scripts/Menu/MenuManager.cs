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

    [Header("HowToPlayButton")]
    public GameObject mainMenuHolder;
    public GameObject howToPlayCamera;
    public GameObject howToPlayHolder;
    public float cameraTransition = 2;

    [Header("Shop")]
    public GameObject shopCamera;
    public GameObject shopHolder;

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

    public void BackToMenuButton()
    {
        chooseCamera.SetActive(false);
        cameraSwitcher.cameras[Mathf.RoundToInt(cameraSwitcher.currentCamera)].SetActive(true);
    }

    public void HowToPlayButton()
    {
        StartCoroutine(SwitchMenus(mainMenuHolder, howToPlayHolder, cameraSwitcher.cameras[Mathf.RoundToInt(cameraSwitcher.currentCamera)], howToPlayCamera));
    }

    public void BackToMenuHowToPlay()
    {
        StartCoroutine(SwitchMenus(howToPlayHolder, mainMenuHolder, howToPlayCamera, cameraSwitcher.cameras[Mathf.RoundToInt(cameraSwitcher.currentCamera)]));
    }

    public void ShopButton()
    {
        StartCoroutine(SwitchMenus(mainMenuHolder, shopHolder, cameraSwitcher.cameras[Mathf.RoundToInt(cameraSwitcher.currentCamera)], shopCamera));
    }
    public void BackFromShopButton()
    {
        StartCoroutine(SwitchMenus(shopHolder, mainMenuHolder, shopCamera, cameraSwitcher.cameras[Mathf.RoundToInt(cameraSwitcher.currentCamera)]));
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

    IEnumerator SwitchMenus(GameObject ObjectToDeactivate, GameObject ObjectToActivate, GameObject CamToDeactivate, GameObject CamToActivate)
    {
        ObjectToDeactivate.SetActive(false);
        CamToDeactivate.SetActive(false);
        CamToActivate.SetActive(true);
        yield return new WaitForSeconds(cameraTransition);
        if (ObjectToActivate != null)
        {
            ObjectToActivate.SetActive(true);
        }
    }
}
