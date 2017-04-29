using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private bool pickedUp = false;

    private enum Effects { Heal, SpeedBoost }

    [Header("Effect")]
    [SerializeField]
    private Effects effect;
    [SerializeField]
    private int healAmount = 20;
    [SerializeField]
    private float effectDuration = 10;

    [Header("Audio")]
    [SerializeField]
    private AudioClip pickUpAudioClip;
    [SerializeField]
    private AudioClip deniedAudioClip;
    private AudioSource audioSource;

    [Header("Sphere transform")]
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float deflationSpeed;

    private new Light light;

    [Header("Light")]
    [SerializeField]
    private float lightIntensitySpeed;
    [SerializeField]
    private float lightIntensityAmplitude;

    private float initialLightIntensity;

    [Header("Particle System")]
    [SerializeField]
    private new ParticleSystem particleSystem;

    [Header("Color")]
    [SerializeField]
    private Color color;

    // Player components
    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        light = GetComponent<Light>();
        initialLightIntensity = light.intensity;

        light.color = color;
        GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0.5f);

        player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMovement = player.GetComponent<PlayerMovement>();

        var main = particleSystem.main;
        main.startColor = color;
    }

    private void Update()
    {
        if (!pickedUp)
        {
            transform.Rotate(0, 0, Time.deltaTime * 30, Space.Self);
            light.intensity = initialLightIntensity + lightIntensityAmplitude * Mathf.Sin(lightIntensitySpeed * Time.time);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(), Time.deltaTime * deflationSpeed);
            light.intensity = Mathf.Lerp(light.intensity, 0, Time.deltaTime * deflationSpeed);

            if (transform.localScale.x < 0.01f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !pickedUp)
        {
            switch (effect)
            {
                case Effects.Heal:
                    if (playerHealth.Health < playerHealth.MaxHealth)
                    {
                        playerHealth.Heal(healAmount);
                        pickedUp = true;
                    }
                    break;
                case Effects.SpeedBoost:

                    break;
            }

            if (pickedUp)
            {
                audioSource.PlayOneShot(pickUpAudioClip);
                particleSystem.Play();
            }
            else
            {
                audioSource.PlayOneShot(deniedAudioClip);
            }
        }
    }
}