using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle movement
/// </summary>
public class PlayerMovement : MonoBehaviour {

	public void LookAt(Vector3 point)
    {
        Vector3 heightCorrectedPoint = new Vector3(point.x, transform.position.y, point.z);

        transform.LookAt(heightCorrectedPoint);

        /*Quaternion newPos = Quaternion.LookRotation(heightCorrectedPoint);

        transform.rotation = Quaternion.Lerp(transform.rotation, newPos, 5f * Time.deltaTime);*/
    }
}