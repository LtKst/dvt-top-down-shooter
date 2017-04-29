using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

    [SerializeField]
    private float cycleSpeed = 0.05f;

	private void Update () {
        transform.Rotate(Vector3.right * cycleSpeed);
	}
}
