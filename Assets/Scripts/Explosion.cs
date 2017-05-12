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

    private GameObject[] breakables;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

	private void Start () {
        // Damage player
        if (GameObject.FindWithTag("Player"))
        {
            distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distanceFromPlayer < damageRange && (int)distanceFromPlayer > 0)
            {
                player.GetComponent<PlayerHealth>().ModifyHealth(-(damage / (int)distanceFromPlayer));
            }
            else if ((int)distanceFromPlayer <= 0)
            {
                player.GetComponent<PlayerHealth>().ModifyHealth(-damage);
            }
        }

        // Damage enemies
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(transform.position, enemies[i].transform.position) <= damageRange)
            {
                enemies[i].GetComponent<EnemyHealth>().Die(false);
            }
        }

        // Break other breakables
        breakables = GameObject.FindGameObjectsWithTag("Breakable");

        for (int i = 0; i < breakables.Length; i++)
        {
            if (Vector3.Distance(transform.position, breakables[i].transform.position) <= damageRange)
            {
                breakables[i].GetComponent<Breakable>().Hit();
            }
        }
    }
}
