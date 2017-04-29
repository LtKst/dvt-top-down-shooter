using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the projectile forward
/// </summary>
public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed = 40;
    private Rigidbody rb;

    private Transform playerTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) > 100)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector3 velocity = transform.forward * (Time.fixedDeltaTime * speed);
        rb.MovePosition(rb.position + velocity);
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<EnemyHealth>())
        {
            hit.GetComponent<EnemyHealth>().Die();
            Destroy(gameObject);
        }
        else if (hit.GetComponent<Breakable>())
        {
            hit.GetComponent<Breakable>().Hit();
            Destroy(gameObject);
        }
    }
}