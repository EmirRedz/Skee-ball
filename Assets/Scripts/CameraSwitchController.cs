using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchController : MonoBehaviour
{
    private MoveBall moveBall;
    [SerializeField] private GameObject mainCam, shotCam;
    [SerializeField] private GameObject scoreText, ballText;
    [SerializeField] private float toggleTextDelay = 1;
    private float lastToggleText = 0;
    private void Awake()
    {
        moveBall = GetComponent<MoveBall>();
    }

    private void Start()
    {
        lastToggleText = toggleTextDelay;
    }

    // Update is called once per frame
    void Update()
    {
        CameraSwitch();
    }

    private void CameraSwitch()
    {
        shotCam.SetActive(moveBall.ballOnStage);
        mainCam.SetActive(!moveBall.ballOnStage);

        if (moveBall.ballOnStage)
        {
            scoreText.SetActive(false);
            ballText.SetActive(false);
            lastToggleText = toggleTextDelay;
        }
        else
        {
            
            if (lastToggleText <= 0)
            {
                scoreText.SetActive(true);
                ballText.SetActive(true);
                lastToggleText = toggleTextDelay;
            }
            else
            {
                lastToggleText -= Time.deltaTime;
            }
            
        }
    }

    IEnumerator ToggleText()
    {
        yield return new WaitForSeconds(toggleTextDelay);
        scoreText.SetActive(true);
        ballText.SetActive(true);     
    }
}
