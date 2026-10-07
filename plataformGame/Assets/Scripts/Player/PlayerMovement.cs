using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Components
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    private Vector2 move;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void Move()
    {
        move.x = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (move.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (move.x < 0) 
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnMove()
    {
        rigidbody.linearVelocityX = move.x;
    }

    public int MoveValue()
    {
        return (int)move.x; 
    }
}
