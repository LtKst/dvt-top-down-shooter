using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update () {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime);
    }
}
