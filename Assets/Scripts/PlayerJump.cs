using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _body;

    public float jumpForce = 10f;

    [Header("Ground Check")]
    public LayerMask groundLayer;
    public Vector2 boxSize;
    public float castDistance;

    public bool grounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (InputSystem.actions["Jump"].IsPressed() && grounded)
        {
            _body.linearVelocityY = jumpForce;
        }
    }
    private void FixedUpdate()
    {
        var onGround = IsGrounded();
        //if (onGround && !grounded)
        //{
        //    _animator.SetBool(Jump, false);
        //}
        grounded = onGround;
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }
}
