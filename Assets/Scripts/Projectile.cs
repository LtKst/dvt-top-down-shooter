using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the projectile forward
/// </summary>
public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed = 40;
    private Rigidbody rigidbody;

    private Transform playerTransform;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(playerTransform.position, transform.position) > 100)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = transform.forward * (Time.fixedDeltaTime * speed);
        rigidbody.MovePosition(rigidbody.position + velocity);
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<EnemyHealth>())
        {
            hit.GetComponent<EnemyHealth>().Die();
            Destroy(gameObject);
        }
        else if (hit.GetComponent<ProjectileObstacle>())
        {
            hit.GetComponent<ProjectileObstacle>().Hit(gameObject.transform.forward);
            Destroy(gameObject);
        }
    }
}