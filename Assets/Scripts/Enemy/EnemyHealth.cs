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

    [SerializeField]
    private int killPoints = 25;

    private Rigidbody rb;
    
    private bool isDead;

    private PlayerScore playerScore;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        playerScore = GameObject.FindWithTag("Player").GetComponent<PlayerScore>();
    }

    public void Die(bool deathByPlayer)
    {
        audioSource.PlayOneShot(hitAudioClip);

        if (!isDead)
        {
            audioSource.PlayOneShot(shutdownAudioClip);

            smoke.SetActive(true);
            rb.useGravity = true;

            if (deathByPlayer)
            {
                playerScore.IncreaseScore(killPoints);
            }
        }

        isDead = true;
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }
}
