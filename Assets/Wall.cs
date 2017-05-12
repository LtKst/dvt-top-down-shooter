using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

    private GameObject[] enemies;

	void LateUpdate () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            Physics.IgnoreCollision(enemies[i].GetComponent<Collider>(), GetComponent<Collider>());
        }
	}
}
