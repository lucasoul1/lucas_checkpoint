using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Components

    private Rigidbody2D rigidbody;

    [Header("Sensor Settings")]
    [SerializeField] private Transform sensorPosition;
    [SerializeField] private Vector3 sensorSize;
    [SerializeField] private LayerMask layerGround;

    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 1.4f;
    [SerializeField] private float jumpTime = 0.15f;
    private float currentJumpTime;
    private bool grounded;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        OnJump();
    }

    private void Jump()
    {
        grounded = Physics2D.OverlapBox(sensorPosition.position, sensorSize, 0, layerGround);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            currentJumpTime = jumpTime;
        }
        else if (Input.GetButton("Jump") && currentJumpTime > 0)
        {
            currentJumpTime -= Time.deltaTime;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            currentJumpTime = 0;
        }
    }

    private void OnJump()
    {
        if (currentJumpTime > 0)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public int JumpValue()
    {
        return (int)rigidbody.linearVelocityY;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(sensorPosition.position, sensorSize);
    }
}
