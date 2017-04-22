using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle input
/// </summary>
public class PlayerInput : MonoBehaviour {

    private PlayerMovement playerMovement;
    private PlayerShoot playerShoot;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
    }

    void Update()
    {
        // Movement
        playerMovement.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Rotation
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            playerMovement.LookAt(hit.point);

            Debug.DrawRay(ray.origin, ray.direction * 100);
        }

        // Shooting
        if (Input.GetMouseButton(0))
        {
            playerShoot.Shoot();
        }

        // Reloading
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerShoot.isReloading = true;
        }
    }
}