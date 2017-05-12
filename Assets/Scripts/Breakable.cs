using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hittable objects
/// </summary>
public class Breakable : MonoBehaviour {

    // Audio variables
    [Header("Audio")]
    [SerializeField]
    private bool playSoundOnHit;
    [SerializeField]
    private AudioClip[] hitAudioClip;
    private AudioSource audioSource;

    // Spawn object variables
    [Header("Spawn objects")]
    [SerializeField]
    private bool spawnObjectOnHit;
    [SerializeField]
    private GameObject spawnOnHit;

    // Destroy variables
    [Header("Destroy")]
    [SerializeField]
    private bool destroyOnHit;

    private void Awake()
    {
        if (gameObject.GetComponent<AudioSource>() && playSoundOnHit)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }
        else if (!gameObject.GetComponent<AudioSource>() && playSoundOnHit)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void Hit()
    {
        if (playSoundOnHit)
        {
            audioSource.PlayOneShot(hitAudioClip[Random.Range(0, hitAudioClip.Length)]);
        }

        if (spawnObjectOnHit)
        {
            GameObject spawnOnHitInstance = Instantiate(spawnOnHit);
            spawnOnHitInstance.transform.position = transform.position;
        }

        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}