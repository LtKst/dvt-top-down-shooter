using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private AudioClip pickUpClip;

    private AudioSource audioSource;

    private Animation animation;

    private bool pickedUp = false;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        animation = gameObject.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !pickedUp)
        {
            audioSource.PlayOneShot(pickUpClip);
            animation.Play();

            pickedUp = true;
        }
    }
}
