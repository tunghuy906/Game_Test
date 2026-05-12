using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;

    private Vector3 moveDirection;

    public float MoveAmount { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandleInput()
    {
        float horizontal =
            Input.GetAxisRaw("Horizontal");

        float vertical =
            Input.GetAxisRaw("Vertical");

        moveDirection =
            new Vector3(horizontal, 0f, vertical)
            .normalized;

        MoveAmount = moveDirection.magnitude;
    }

    private void Move()
    {
        rb.velocity =
            new Vector3(
                moveDirection.x * moveSpeed,
                0f,
                moveDirection.z * moveSpeed
            );
    }

    private void Rotate()
    {
        if (moveDirection == Vector3.zero)
            return;

        transform.forward = moveDirection;
    }
}