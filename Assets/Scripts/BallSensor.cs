using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class BallSensor : MonoBehaviour
{
    private GameManager _GM;

    public int sensorValue = 0;
    public TMP_Text scoreReference;
    public GameObject gameOver;
    private MoveBall moveBall;
    private void Awake()
    {
        _GM = FindObjectOfType<GameManager>();
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
        moveBall.canShoot = false;
        scoreReference.text = (int.Parse(scoreReference.text) + (sensorValue * other.gameObject.GetComponent<BallMultiplier>().multiplier)).ToString();

        moveBall.ballsLeft--;
        moveBall.ballText.text = moveBall.ballsLeft.ToString();

        if(moveBall.ballsLeft == 0)
        {
            _GM.EndGame();
        }
    }
}
