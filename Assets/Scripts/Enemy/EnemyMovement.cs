using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 1f;

    private GameObject player;
    private EnemyHealth enemyHealth;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update () {
        if (!enemyHealth.isDead && GameObject.FindWithTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * movementSpeed);
        }
    }
}
