using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenTransition : MonoBehaviour
{
    public string sceneName = "Menu";
    public float splashScreenTime = 3;
    MenuManager _manager;

    private void Awake()
    {
        _manager = GetComponent<MenuManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(splashScreenTime);
        _manager.LoadScene(sceneName);
    }
}
