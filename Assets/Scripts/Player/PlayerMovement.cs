using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handle movement
/// </summary>
public class PlayerMovement : MonoBehaviour {

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    [SerializeField]
    private float moveSpeed = 7;
    private float initialMoveSpeed;
    private bool moveSpeedIncreased = false;

    private float timer;

    private Rigidbody rb;

    private void Awake()
    {
        initialMoveSpeed = moveSpeed;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (moveSpeedIncreased && timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            moveSpeedIncreased = false;
            moveSpeed = initialMoveSpeed;
        }
    }

    public void LookAt(Vector3 point)
    {
        Vector3 heightCorrectedPoint = new Vector3(point.x, transform.position.y, point.z);

        transform.LookAt(heightCorrectedPoint);
    }

    public void Move(float horizontal, float vertical)
    {
        moveInput = new Vector3(horizontal, 0f, vertical);
        moveVelocity = moveInput * moveSpeed;

        rb.velocity = moveVelocity;
    }

    public void IncreaseSpeed(float newSpeed, float duration)
    {
        moveSpeed = newSpeed;
        timer = duration;
        moveSpeedIncreased = true;
    }

    public bool MoveSpeedIncreased
    {
        get
        {
            return moveSpeedIncreased;
        }
    }
}