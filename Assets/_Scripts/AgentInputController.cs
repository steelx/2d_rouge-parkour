using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
public class AgentInputController : MonoBehaviour
{
    Camera mainCamera;
    PlayerInput inputController;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction aimAction;
    InputAction lookAction;

    Rigidbody2D playerRb;
    Vector2 movementDirection;
    float currentSpeed;

    [field: SerializeField] UnityEvent<float> OnVelocityChange { get; set; }
    [field: SerializeField] UnityEvent<Vector2> OnPointerPositionChange { get; set; }
    [field: SerializeField]  MovementDataSO MovementData { get; set; }
    void Start()
    {
        inputController = gameObject.GetComponent<PlayerInput>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        moveAction = inputController.actions["Move"];
        jumpAction = inputController.actions["Jump"];
        lookAction = inputController.actions["PointerPosition"];
        aimAction = inputController.actions["Aim"];
    }

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        this.GetPointerPosition();
    }

    private void FixedUpdate() {
        this.MoveAgent(moveAction.ReadValue<Vector2>());
    }

    void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.magnitude > 0)
        {
            this.movementDirection = movementInput.normalized;
        }
        this.currentSpeed = CalculateSpeed(movementInput);
        this.OnVelocityChange?.Invoke(this.currentSpeed);
        playerRb.velocity = this.currentSpeed * this.movementDirection.normalized;
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

    void GetPointerPosition()
    {
        Vector2 pointerPosition = lookAction.ReadValue<Vector2>();
        Vector2 mousePointerWorldPosition = mainCamera.ScreenToWorldPoint(pointerPosition);
        OnPointerPositionChange?.Invoke(mousePointerWorldPosition);
    }
}
