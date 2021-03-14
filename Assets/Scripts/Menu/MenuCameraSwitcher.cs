using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraSwitcher : MonoBehaviour
{
    public GameObject[] cameras;
    public float switchRate = 1;
    public float currentCamera;
    private bool isCountingDone;

    [Header("Title screen")]
    public Animator menuAnimator;

    // Update is called once per frame
    void Update()
    {
        Invoke("SwitchCameras", 1.3f);
    }

    private void SwitchCameras()
    {
        if (!isCountingDone)
        {
            currentCamera += Time.deltaTime * switchRate;
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            cameras[Mathf.RoundToInt(currentCamera)].SetActive(true);
        }


        if (currentCamera >= cameras.Length - 1)
        {
            currentCamera = cameras.Length - 1;
            isCountingDone = true;
            menuAnimator.SetTrigger("fadeIn");
        }
    }
}
