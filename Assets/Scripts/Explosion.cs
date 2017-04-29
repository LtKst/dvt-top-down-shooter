using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    [SerializeField]
    private int damage = 20;
    [SerializeField]
    private float damageRange = 10;

    private GameObject player;
    private float distanceFromPlayer;

    private GameObject[] enemies;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

	void Start () {
        if (GameObject.FindWithTag("Player"))
        {
            // Damage player
            distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceFromPlayer < damageRange && (int)distanceFromPlayer > 0)
            {
                player.GetComponent<PlayerHealth>().Damage(damage / (int)distanceFromPlayer);
            }
            else if ((int)distanceFromPlayer <= 0)
            {
                player.GetComponent<PlayerHealth>().Damage(damage);
            }
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Damage enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) < damageRange)
            {
                enemies[i].GetComponent<EnemyHealth>().Die();
            }
        }
    }
}
