using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLightSwitcher : MonoBehaviour
{
    Light _light;

    public float rate = 1;
    public Renderer cielingRenderer;
    private float lerpSpeed = 0;

    Color startColor,endColor;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        startColor = new Color(Random.value, Random.value, Random.value);
        endColor = new Color(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        lerpSpeed += Time.deltaTime * rate;
        _light.color = Color.Lerp(startColor, endColor, lerpSpeed);
        if(lerpSpeed >= 1)
        {
            lerpSpeed = 0;
            startColor = _light.color;
            endColor = new Color(Random.value, Random.value, Random.value);
        }
    }

    private void LateUpdate()
    {
        cielingRenderer.material.SetColor("_EmissionColor", _light.color);
    }
}
