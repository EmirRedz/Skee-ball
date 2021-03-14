using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip mainTheme;
    string sceneName;

    void Start()
    {
        OnLevelWasLoaded(0);
    }


    void OnLevelWasLoaded(int sceneIndex)
    {
        AudioListener.pause = false;
        string newSceneName = SceneManager.GetActiveScene().name;
        if (newSceneName != sceneName)
        {
            sceneName = newSceneName;
            Invoke("PlayMusic", .2f);
        }
    }

    void PlayMusic()
    {
        AudioClip clipToPlay = null;

        if (sceneName == "Menu" || sceneName == "Game")
        {
            clipToPlay = mainTheme;
        }
        if (clipToPlay != null)
        {
            AudioManager.Instance.PlayMusic(clipToPlay, 1.3f);
            Invoke("PlayMusic", clipToPlay.length);
        }

    }
}
