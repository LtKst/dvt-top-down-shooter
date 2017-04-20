using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle shooting
/// </summary>
public class PlayerShoot : MonoBehaviour {

    [SerializeField]
    private GameObject projectile;

    private Transform parent;

    private AudioSource audioSource;

    [SerializeField]
    private int bulletsCapacity = 32;
    private int bulletsInMag;

    [SerializeField]
    private float reloadTime = 2;
    private float initialReloadTime;

    [HideInInspector]
    public bool isReloading = false;

    private bool reloadSoundPlayed = false;

    [SerializeField]
    private AudioClip shootAudioClip;
    [SerializeField]
    private AudioClip reloadAudioClip;

    [SerializeField]
    private float shootDelay = 0.3f;
    private float initialShootDelay;

    [SerializeField]
    private RectTransform ammoBarRect;
    private float initialAmmoBarWidth;
    [SerializeField]
    private UnityEngine.UI.Text ammoText;

    private void Awake()
    {
        parent = GameObject.FindGameObjectWithTag("ProjectileParent").transform;

        audioSource = gameObject.GetComponent<AudioSource>();

        bulletsInMag = bulletsCapacity;

        initialReloadTime = reloadTime;

        initialShootDelay = shootDelay;

        initialAmmoBarWidth = ammoBarRect.sizeDelta.x;
    }

    void Update()
    {
        ammoText.text = bulletsInMag.ToString() + "/" + bulletsCapacity.ToString();

        if (isReloading && reloadTime >= 0)
        {
            reloadTime -= Time.deltaTime;

            if (!reloadSoundPlayed)
            {
                audioSource.PlayOneShot(reloadAudioClip);
                reloadSoundPlayed = true;
            }
        }
        else if (isReloading && reloadTime <= 0)
        {
            bulletsInMag = bulletsCapacity;
            isReloading = false;
            reloadTime = initialReloadTime;
            reloadSoundPlayed = false;
        }

        if (shootDelay >= 0)
            shootDelay -= Time.deltaTime;

        ammoBarRect.sizeDelta = Vector2.Lerp(ammoBarRect.sizeDelta, new Vector2(initialAmmoBarWidth - (initialAmmoBarWidth / bulletsCapacity)*(bulletsCapacity-bulletsInMag), ammoBarRect.sizeDelta.y), Time.deltaTime*25);
    }

    public void Shoot()
    {
        if (bulletsInMag > 0 && shootDelay <= 0)
        {
            GameObject projectileInstance = Instantiate(projectile);
            projectileInstance.transform.SetParent(parent);
            projectileInstance.transform.position = gameObject.transform.position;
            projectileInstance.transform.rotation = gameObject.transform.rotation;

            shootDelay = initialShootDelay;

            bulletsInMag -= 1;

            audioSource.PlayOneShot(shootAudioClip);
        }
        else if (bulletsInMag <= 0)
        {
            isReloading = true;
        }
    }
}