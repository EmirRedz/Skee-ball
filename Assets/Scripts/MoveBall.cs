using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveBall : MonoBehaviour
{
    [SerializeField] private float throwSpeed = 1100;
    public GameObject ballPrefab;
    private Vector2 startPos;
    private Vector2 endPos;
    [SerializeField] private Vector2 minDistance = new Vector2(0, 100);
    [SerializeField] private Vector3 ballPos = new Vector3(0, 0.38f, -11.41f);
    public bool ballOnStage;
    public int ballsLeft = 5;
    public TextMeshProUGUI ballText;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                endPos = touch.position;
            }

            if (endPos.y - startPos.y >= minDistance.y && !ballOnStage && ballsLeft > 0)
            {
                if (touch.position.x >= 0 && touch.position.x <= Screen.width / 3)
                {
                    ballPos.x = Random.Range(-0.87f, -0.35f);
                }
                /* Center */
                else if (touch.position.x > Screen.width / 3 && touch.position.x <= (Screen.width / 3) * 2)
                {
                    ballPos.x = Random.Range(-0.35f, 0.22f);
                }
                /* Right */
                else if (touch.position.x > (Screen.width / 3) * 2 && touch.position.x <= Screen.width)
                {
                    ballPos.x = Random.Range(0.22f, 0.36f);
                }

                GameObject ball = Instantiate(ballPrefab, ballPos, transform.rotation);
                ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * throwSpeed, ForceMode.Impulse);

                //play audio

                endPos = Vector2.zero;
                startPos = Vector2.zero;
                ballOnStage = true;
            }
        }
#if UNITY_EDITOR
        Vector2 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
        }

        if (endPos.y - startPos.y >= minDistance.y && !ballOnStage && ballsLeft > 0)
        {
            if (mousePos.x >= 0 && mousePos.x <= Screen.width / 3)
            {
                ballPos.x = Random.Range(-1f, -0.35f);
            }
            /* Center */
            else if (mousePos.x > Screen.width / 3 && mousePos.x <= (Screen.width / 3) * 2)
            {
                ballPos.x = Random.Range(-0.35f, 0.5f);
            }
            /* Right */
            else if (mousePos.x > (Screen.width / 3) * 2 && mousePos.x <= Screen.width)
            {
                ballPos.x = Random.Range(0.5f, 1f);
            }

            GameObject ball = Instantiate(ballPrefab, ballPos, transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * throwSpeed);

            //play audio

            endPos = Vector2.zero;
            startPos = Vector2.zero;
            ballOnStage = true;
        }
#endif
    }
}

      