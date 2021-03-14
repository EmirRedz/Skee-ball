
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Screenshake : MonoBehaviour
{
    public static Screenshake Instance { get; private set; }
    private CinemachineVirtualCamera vcam;
    private CinemachineBasicMultiChannelPerlin shaker;
    private float startingIntensity;
    private float shakerTimeTotal;
    private float shakerTime; 

    private void Awake()
    {
        Instance = this;
        vcam = GetComponent<CinemachineVirtualCamera>(); 
    }

    private void Start()
    {
        shaker = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>(); 
    }

    private void Update()
    {
        if(shakerTime > 0) 
        {
            shaker.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0, shakerTime / shakerTimeTotal);
            shaker.m_FrequencyGain = shakerTime;
            
           
            shakerTime -= Time.deltaTime;
        }
        else
        {
            shaker.m_AmplitudeGain = 0;
            shaker.m_FrequencyGain = 0;
        }
    }

    public void ShakeCamera(float intensity, float time) 
    {
        shaker.m_AmplitudeGain = intensity; 
        shaker.m_FrequencyGain = time; 

        startingIntensity = intensity;
        shakerTimeTotal = time;
        shakerTime = time; 
    }
}
