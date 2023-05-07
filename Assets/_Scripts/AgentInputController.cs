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
    InputAction lookAction;

    [field: SerializeField] UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
    [field: SerializeField] UnityEvent<Vector2> OnPointerPositionChange { get; set; }

    void Start()
    {
        inputController = gameObject.GetComponent<PlayerInput>();

        moveAction = inputController.actions["Move"];
        jumpAction = inputController.actions["Jump"];
        lookAction = inputController.actions["PointerPosition"];
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
        this.GetMovementInput();
    }

    private void GetMovementInput()
    {
        var movementInput = moveAction.ReadValue<Vector2>();
        OnMovementKeyPressed?.Invoke(movementInput);
    }


    void GetPointerPosition()
    {
        Vector2 pointerPosition = lookAction.ReadValue<Vector2>();
        // fix for screen space vs world space ;pointerPosition.z = mainCamera.nearClipPlane;
        Vector2 mousePointerWorldPosition = mainCamera.ScreenToWorldPoint(pointerPosition);
        OnPointerPositionChange?.Invoke(mousePointerWorldPosition);
    }
}
