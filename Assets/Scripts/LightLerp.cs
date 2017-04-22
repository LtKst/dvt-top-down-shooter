using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLerp : MonoBehaviour {

    private Light light;

    [SerializeField]
    private Vector2 between = new Vector2(1, 0.5f);

    [SerializeField]
    private float lerpSpeed = 0.2f;

    private float currentValue;

    private float max;
    private float min;

    private void Awake()
    {
        light = gameObject.GetComponent<Light>();

        max = between.x;
        min = between.y;
    }

    private void Update()
    {
        light.intensity = Mathf.Lerp(light.intensity, min, Time.deltaTime*lerpSpeed);
    }
}
