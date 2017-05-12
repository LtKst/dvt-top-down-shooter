using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    private bool spawnEnemies = true;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float spawnDelay = 5f;
    private float initialSpawnDelay;

    private GameObject enemyInstance;
    private Vector3 tempPosition;

    private bool succesfulSpawn = false;

    private void Awake()
    {
        initialSpawnDelay = spawnDelay;
    }

    private void Update()
    {
        if (spawnEnemies && GameObject.FindWithTag("Player"))
        {
            if (spawnDelay >= 0)
            {
                spawnDelay -= Time.deltaTime;
            }
            else if (spawnDelay <= 0)
            {
                enemyInstance = Instantiate(enemy);
                enemyInstance.SetActive(false);

                while (!succesfulSpawn)
                {
                    tempPosition = new Vector3(Random.Range(-100, 100), 0.5f, Random.Range(-100, 100));

                    succesfulSpawn = true;
                }

                enemyInstance.transform.position = tempPosition;
                enemyInstance.SetActive(true);

                succesfulSpawn = false;

                if (spawnDelay >= 1)
                {
                    ChangeSpawnDelay(initialSpawnDelay - 0.1f);
                }

                spawnDelay = initialSpawnDelay;
            }
        }
    }

    public void ChangeSpawnDelay(float newDelay)
    {
        spawnDelay = newDelay;
        initialSpawnDelay = newDelay;
    }
}
