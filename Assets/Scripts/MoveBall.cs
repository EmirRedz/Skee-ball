using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveBall : MonoBehaviour
{

    CameraSwitchController cameraController;

    public float throwSpeed = 1100;
    public GameObject ballPrefab;
    GameObject ball;
    private Vector2 startPos;
    private Vector2 endPos;
    [SerializeField] private float minDistance = 100;
    [SerializeField] private Vector3 ballPos = new Vector3(0, 0.38f, -11.41f);
    private Vector3 ballSpawnPos;
    [SerializeField] private Vector2 randomLeft, randomMid, randomRight;
    public bool ballOnStage;
    public bool canShoot;
    public int ballsLeft = 5;
    public TMP_Text ballText;

    [Header("Raycast")]
    public float maxDistnace = 50f;
    public LayerMask fieldMask;
    RaycastHit hit;
    Ray ray;

    [Header("Particles")]
    public ParticleSystem throwParticle;
    public Quaternion spawnRot = Quaternion.Euler(0, 180, 0);

    private void Awake()
    {
        cameraController = FindObjectOfType<CameraSwitchController>();
    }

    private void Start()
    {
        ballText.text = ballsLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    { 
        Vector2 mousePos = Input.mousePosition;

        if (Input.GetMouseButton(0) && !ballOnStage && ballsLeft > 0 && cameraController.mainCam.activeInHierarchy)
        {
            ray = Camera.main.ScreenPointToRay(mousePos);
            if(Physics.Raycast(ray, out hit, maxDistnace, fieldMask))
            {
                ballSpawnPos = new Vector3(hit.point.x, ballPos.y, ballPos.z);

                if(ball != null)
                {
                    ball.transform.position = ballSpawnPos;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            if (!ballOnStage && ballsLeft > 0 && !canShoot && cameraController.mainCam.activeInHierarchy)
            {
                ball = Instantiate(ballPrefab, ballSpawnPos, transform.rotation);
                ball.GetComponent<Rigidbody>().isKinematic = true;
                canShoot = true;
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
        }

        if (endPos.y - startPos.y >= minDistance && !ballOnStage && ballsLeft > 0)//Throwing
        {

            if (ball != null)
            {
                ball.GetComponent<Rigidbody>().isKinematic = false;
                ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.2f, 1) * throwSpeed, ForceMode.Acceleration);
                ball.transform.Rotate(Vector3.up * 45 * Time.deltaTime);
            }

            AudioManager.Instance.PlaySound2D("Shoot");

            endPos = Vector2.zero;
            startPos = Vector2.zero;
            ballOnStage = true;
        }

        StuckScreenCheck(10f);
    }

    private void StuckScreenCheck(float threshHold)
    {
        if(cameraController.shotCamDuration >= threshHold)
        {
            DestroyBall();
        }
        else
        {
            return;
        }
    }

    private void DestroyBall()
    {
        ballOnStage = false;
        canShoot = false;
        ballsLeft--;
        ballText.text = ballsLeft.ToString();
        Destroy(ball);
    }
}

      