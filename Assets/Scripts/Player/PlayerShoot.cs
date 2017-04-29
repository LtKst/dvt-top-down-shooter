using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle shooting
/// </summary>
public class PlayerShoot : MonoBehaviour {

    [Header("GameObjects")]
    [SerializeField]
    private Transform gun;
    [SerializeField]
    private GameObject projectile;
    private Transform projectileParent;

    private AudioSource audioSource;

    [Header("Ammo")]
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
    private float shootDelay = 0.3f;
    private float initialShootDelay;

    [Header("Audio")]
    [SerializeField]
    private AudioClip[] shootAudioClip;
    [SerializeField]
    private AudioClip reloadAudioClip;

    [Header("UI")]
    [SerializeField]
    private RectTransform ammoBarRect;
    private float initialAmmoBarWidth;
    [SerializeField]
    private UnityEngine.UI.Text ammoText;

    void Awake()
    {
        projectileParent = new GameObject("Projectile Parent").transform;

        audioSource = gameObject.GetComponent<AudioSource>();

        bulletsInMag = bulletsCapacity;

        initialReloadTime = reloadTime;

        initialShootDelay = shootDelay;

        initialAmmoBarWidth = ammoBarRect.sizeDelta.x;
    }

    void Update()
    {
        // Set UI text
        if (!isReloading)
        {
            ammoText.text = bulletsInMag.ToString() + "/" + bulletsCapacity.ToString();
        }
        else
        {
            ammoText.text = bulletsInMag.ToString() + "/" + bulletsCapacity.ToString() + " Reloading...";
        }

        // Start reloading
        if (isReloading && reloadTime >= 0 && bulletsInMag < bulletsCapacity)
        {
            reloadTime -= Time.deltaTime;

            if (!reloadSoundPlayed)
            {
                audioSource.PlayOneShot(reloadAudioClip);
                reloadSoundPlayed = true;
            }
        }
        // Done Reloading
        else if (isReloading && reloadTime <= 0)
        {
            bulletsInMag = bulletsCapacity;
            isReloading = false;
            reloadTime = initialReloadTime;
            reloadSoundPlayed = false;
        }
        // No need to reload
        else if (bulletsInMag >= bulletsCapacity)
        {
            isReloading = false;
        }

        if (shootDelay >= 0)
        {
            shootDelay -= Time.deltaTime;
        }

        ammoBarRect.sizeDelta = Vector2.Lerp(ammoBarRect.sizeDelta, new Vector2(initialAmmoBarWidth - (initialAmmoBarWidth / bulletsCapacity)*(bulletsCapacity-bulletsInMag), ammoBarRect.sizeDelta.y), Time.deltaTime*25);
    }

    public void Shoot()
    {
        if (bulletsInMag > 0 && shootDelay <= 0)
        {
            GameObject projectileInstance = Instantiate(projectile);
            projectileInstance.transform.SetParent(projectileParent);
            projectileInstance.transform.position = gun.position;
            projectileInstance.transform.rotation = gameObject.transform.rotation;

            shootDelay = initialShootDelay;

            bulletsInMag -= 1;

            audioSource.PlayOneShot(shootAudioClip[Random.Range(0, shootAudioClip.Length)]);
        }
        else if (bulletsInMag <= 0)
        {
            isReloading = true;
        }
    }

    public int BulletCapacity
    {
        get
        {
            return bulletsCapacity;
        }
        set
        {
            bulletsCapacity = value;
        }
    }
}