using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D car_BackWheel;
    [SerializeField] private Rigidbody2D car_FrontWheel;
    [SerializeField] private Rigidbody2D Player;
    
    private float speed = 500f;
    private float rotationSpeed = 300f;

    PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

    }

    private void Update()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        float inputVectorX = inputVector.x;

        car_FrontWheel.AddTorque(inputVectorX * speed * Time.fixedDeltaTime);
        car_BackWheel.AddTorque(inputVectorX * speed * Time.fixedDeltaTime);
        Player.AddTorque(inputVectorX * rotationSpeed * Time.fixedDeltaTime);
    }
}
