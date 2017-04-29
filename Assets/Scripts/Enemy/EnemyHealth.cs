using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    private AudioClip hitAudioClip;
    [SerializeField]
    private AudioClip shutdownAudioClip;
    private AudioSource audioSource;

    [SerializeField]
    private GameObject smoke;

    private Rigidbody rb;

    [HideInInspector]
    public bool isDead;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    public void Die()
    {
        audioSource.PlayOneShot(hitAudioClip);

        if (!isDead)
        {
            isDead = true;

            audioSource.PlayOneShot(shutdownAudioClip);

            smoke.SetActive(true);
            rb.useGravity = true;
        }
    }
}
