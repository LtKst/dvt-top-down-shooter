using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private bool dead;

    private void Update()
    {
        if (dead)
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 50, 0), ForceMode.Force);
    }

    public void Die()
    {
        dead = true;
    }
}
