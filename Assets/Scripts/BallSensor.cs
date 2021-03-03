using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BallSensor : MonoBehaviour
{
    public int sensorValue = 0;
    public TextMeshProUGUI scoreReference;
    public GameObject gameOver;
    private MoveBall moveBall;

    private void Awake()
    {
        moveBall = Camera.main.GetComponent<MoveBall>();
    }

    private void Start()
    {
        gameOver.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        moveBall.ballOnStage = false;
        scoreReference.text = (int.Parse(scoreReference.text) + sensorValue).ToString();

        moveBall.ballsLeft--;
        moveBall.ballText.text = moveBall.ballsLeft.ToString();

        if(moveBall.ballsLeft == 0)
        {
            gameOver.SetActive(true);
            Invoke("ReloadGame", 3);
        }

    }

    private void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
