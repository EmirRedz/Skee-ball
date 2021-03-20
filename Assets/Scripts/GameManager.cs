using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Ball Tiers")]
    public MoveBall moveBall;
    public character_selection charSelection;
    public GameObject[] Balls; //Billy 0 / Bart 1/Penelope 2 /Clown 3/Cowboy 4/Sarge 5/Joe 6
    public float ballCheckDelay = 0.45f;

    [Header("EndGame")]
    public GameObject endGameHolder;
    private Animator endGameAnimator;
    public TMP_Text scoreTextReference;
    public TextMeshProUGUI scoreText;

    public int ticketsEarned;
    private int totalTickets;
    public TextMeshProUGUI ticketsText;


    private void Awake()
    {
        endGameAnimator = endGameHolder.GetComponent<Animator>();
    }

    private void Start()
    {
        StartCoroutine(BallSetter());
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void SetBalls()
    {
        StartCoroutine(BallSetter());
    }

    IEnumerator BallSetter()
    {
        while (Application.isPlaying)
        {
            if (charSelection.activeBallName == "Billy")
            {
                moveBall.ballPrefab = NextBallBilly();
            }
            else if (charSelection.activeBallName == "Bart")
            {
                moveBall.ballPrefab = NextBallBart();
            }
            else if (charSelection.activeBallName == "Penelope")
            {
                moveBall.ballPrefab = NextBallPenelope();
            }
            else if (charSelection.activeBallName == "Clown")
            {
                moveBall.ballPrefab = NextBallClown();
            }
            else if (charSelection.activeBallName == "Cowboy")
            {
                moveBall.ballPrefab = NextBallCowboy();
            }
            else if (charSelection.activeBallName == "Sarge")
            {
                moveBall.ballPrefab = NextBallSarge();
            }
            else if (charSelection.activeBallName == "Joe")
            {
                moveBall.ballPrefab = NextBallJoe();
            }
            yield return new WaitForSeconds(ballCheckDelay);
        }
    }

    #region Set Balls

    private GameObject NextBallBilly()
    {
        GameObject nextBall;
        if (moveBall.ballsLeft <= 3)
        {
            nextBall = Balls[1];
        }
        else
        {
            nextBall = Balls[0];
        }
        return nextBall;
    }

    private GameObject NextBallBart()
    {
        GameObject nextBall;
        if(moveBall.ballsLeft <= 3)
        {
            nextBall = Balls[0];
        }
        else
        {
            nextBall = Balls[1];
        }
        return nextBall;
    }

    private GameObject NextBallPenelope()
    {
        GameObject nextBall;
        if (moveBall.ballsLeft <= 1)
        {
            nextBall = Balls[2];
        }
        else if(moveBall.ballsLeft <= 4)
        {
            nextBall = Balls[1];
        }
        else
        {
            nextBall = Balls[0];
        }
        return nextBall;
    }

    private GameObject NextBallClown()
    {
        GameObject nextBall;
        if (moveBall.ballsLeft <= 1)
        {
            nextBall = Balls[3];
        }
        else if (moveBall.ballsLeft <= 2)
        {
            nextBall = Balls[2];
        }
        else if(moveBall.ballsLeft <= 4)
        {
            nextBall = Balls[1];
        }
        else
        {
            nextBall = Balls[0];

        }
        return nextBall;
    }

    private GameObject NextBallCowboy()
    {
        GameObject nextBall;
        if (moveBall.ballsLeft <= 1)
        {
            nextBall = Balls[4];
        }
        else if (moveBall.ballsLeft <= 2)
        {
            nextBall = Balls[3];
        }
        else if (moveBall.ballsLeft <= 3)
        {
            nextBall = Balls[2];
        }
        else if(moveBall.ballsLeft <= 5)
        {
            nextBall = Balls[1];
        }
        else
        {
            nextBall = Balls[0];

        }
        return nextBall;
    }

    private GameObject NextBallSarge()
    {
        GameObject nextBall;
        if (moveBall.ballsLeft <= 1)
        {
            nextBall = Balls[5];
        }
        else if (moveBall.ballsLeft <= 2)
        {
            nextBall = Balls[4];
        }
        else if (moveBall.ballsLeft <= 3)
        {
            nextBall = Balls[3];
        }
        else if (moveBall.ballsLeft <= 4)
        {
            nextBall = Balls[2];
        }
        else if(moveBall.ballsLeft <= 6)
        {
            nextBall = Balls[1];
        }
        else
        {
            nextBall = Balls[0];

        }
        return nextBall;
    }

    private GameObject NextBallJoe()
    {
        GameObject nextBall;
        if (moveBall.ballsLeft == 1)
        {
            nextBall = Balls[6];
        }
        else if (moveBall.ballsLeft == 2)
        {
            nextBall = Balls[5];
        }
        else if (moveBall.ballsLeft == 3)
        {
            nextBall = Balls[4];
        }
        else if (moveBall.ballsLeft == 4)
        {
            nextBall = Balls[3];
        }
        else if (moveBall.ballsLeft == 5)
        {
            nextBall = Balls[2];
        }
        else if (moveBall.ballsLeft == 6)
        {
            nextBall = Balls[1];
        }
        else
        {
            nextBall = Balls[0];

        }
        return nextBall;
    }

    #endregion

    public void EndGame()
    {
        endGameHolder.SetActive(true);
        endGameAnimator.SetTrigger("isIn");
        scoreText.text ="Score " + scoreTextReference.text;
        ticketsEarned = int.Parse(scoreTextReference.text)/ 10;
        ticketsText.text = "Tickets:" + ticketsEarned;
        IncreaseTickets();
    }

    private void IncreaseTickets()
    {
        PlayerPrefs.SetInt("TotalTickets", ticketsEarned + Score.totalTickets);
    }
}
