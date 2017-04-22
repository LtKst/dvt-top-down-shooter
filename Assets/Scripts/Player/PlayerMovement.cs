using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle movement
/// </summary>
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 0.2f;

	public void LookAt(Vector3 point)
    {
        Vector3 heightCorrectedPoint = new Vector3(point.x, transform.position.y, point.z);

        transform.LookAt(heightCorrectedPoint);
    }

    public void Move(float horizontal, float vertical)
    {
        transform.parent.transform.Translate(new Vector3(horizontal*speed, 0, vertical*speed));
    }
}