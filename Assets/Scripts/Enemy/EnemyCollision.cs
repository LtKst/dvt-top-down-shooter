using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    [SerializeField]
    private GameObject spawnOnPlayerHit;
    private GameObject spawnOnPlayerHitInstance;

    private EnemyHealth enemyHealth;

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (!enemyHealth.IsDead)
        {
            if (col.gameObject.tag == "Player")
            {
                spawnOnPlayerHitInstance = Instantiate(spawnOnPlayerHit);
                spawnOnPlayerHitInstance.transform.position = transform.position;

                Destroy(gameObject);
            }
            else if (col.gameObject.GetComponent<Breakable>())
            {
                col.gameObject.GetComponent<Breakable>().Hit();
            }
        }
    }
}
