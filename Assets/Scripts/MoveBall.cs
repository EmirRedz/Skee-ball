using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoveBall : MonoBehaviour
{
    public float throwSpeed = 1100;
    public GameObject ballPrefab;
    GameObject ball;
    private Vector2 startPos;
    private Vector2 endPos;
    [SerializeField] private Vector2 minDistance = new Vector2(0, 100);
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


    private void Start()
    {
        ballText.text = ballsLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    { 
        Vector2 mousePos = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(mousePos);
            if(Physics.Raycast(ray, out hit, maxDistnace, fieldMask))
            {
                Debug.Log("hit floor here: " + hit.point);
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
            if (!ballOnStage && ballsLeft > 0 && !canShoot)
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

        if (endPos.y - startPos.y >= minDistance.y && !ballOnStage && ballsLeft > 0)
        {
            //if (mousePos.x >= 0 && mousePos.x <= Screen.width / 3)
            //{
            //    ballPos.x = Random.Range(-randomLeft.x, randomLeft.y);
            //}
            ///* Center */
            //else if (mousePos.x > Screen.width / 3 && mousePos.x <= (Screen.width / 3) * 2)
            //{
            //    ballPos.x = Random.Range(randomMid.x, randomMid.y);
            //}
            ///* Right */
            //else if (mousePos.x > (Screen.width / 3) * 2 && mousePos.x <= Screen.width)
            //{
            //    ballPos.x = Random.Range(randomRight.x, randomRight.y);
            //}
            if (ball != null)
            {
                ball.GetComponent<Rigidbody>().isKinematic = false;
                ball.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0.2f, 1) * throwSpeed, ForceMode.Acceleration);
                ball.transform.Rotate(Vector3.up * 45 * Time.deltaTime);
            }

            AudioManager.Instance.PlaySound2D("Shoot");
            //ParticleSystem newThrowParticle = Instantiate(throwParticle, ball.transform.position + (Vector3.forward * 2), spawnRot);
            //Destroy(newThrowParticle, 1);
            endPos = Vector2.zero;
            startPos = Vector2.zero;
            ballOnStage = true;
        }
    }
}

      