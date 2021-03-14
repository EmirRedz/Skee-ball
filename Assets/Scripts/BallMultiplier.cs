using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMultiplier : MonoBehaviour
{
    public int multiplier = 1;
    private MoveBall ballController;

    public float minForce = 600, maxForce = 900;

    public ParticleSystem scoreParticle;
    public Quaternion spawnRot = Quaternion.Euler(0, 180, 0);
    public float shakeIntensity, shakeTime = 0.5f;
    
    private void Awake()
    {
        ballController = FindObjectOfType<MoveBall>();
    }
    private void Start()
    {
        shakeIntensity = multiplier;
        ballController.throwSpeed = Random.Range(minForce, maxForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Holes"))
        {
            Screenshake.Instance.ShakeCamera(shakeIntensity, shakeTime);

            ParticleSystem newScoreParticle = Instantiate(scoreParticle, transform.position, Quaternion.identity);
            Destroy(newScoreParticle, 1.5f);

            AudioManager.Instance.PlaySound2D("Score");
        }
    }
}
