using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{

    Rigidbody2D playerRb;
    Vector2 movementDirection;
    float currentSpeed;

    [field: SerializeField] UnityEvent<float> OnVelocityChange { get; set; }
    [field: SerializeField]  MovementDataSO MovementData { get; set; }

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        this.OnVelocityChange?.Invoke(this.currentSpeed);
        playerRb.velocity = this.currentSpeed * this.movementDirection.normalized;
    }

    // MoveAgent will receive the movement input from the AgentInputController event
    public void MoveAgent(Vector2 movementInput)
    {
        this.movementDirection = movementInput.normalized;
        this.currentSpeed = CalculateSpeed(movementInput);
    }

    float CalculateSpeed(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            this.currentSpeed += MovementData.acceleration * Time.deltaTime;
        } else {
            this.currentSpeed -= MovementData.deacceleration * Time.deltaTime;
        }

        return Mathf.Clamp(this.currentSpeed, 0, MovementData.maxSpeed);
    }
}
