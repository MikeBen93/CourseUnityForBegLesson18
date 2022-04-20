using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpForce = 10f;
    private bool _touchedGround = true;

    [Header("Movement vars")]
    [SerializeField] private float jumpOffsetRadius = 0.5f;
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private AnimationCurve curve;

    private Animator _playerAnimator;
    private Rigidbody2D _playerRB2D;
    private Health _playerHealth;

    private bool _isJumping;
    private bool _facingRight;  // For determining which way the player is currently facing.

    public bool IsFacingRight
    {
        get
        {
            return _facingRight;
        }
    }

    private void Awake()
    {
        _playerRB2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _playerHealth = GetComponent<Health>();

        _isJumping = false;
        _facingRight = true;
    }

    private void FixedUpdate()
    {
        _touchedGround = Physics2D.OverlapCircle(groundColliderTransform.position, jumpOffsetRadius, groundMask);
    }

    public void Move(float horizontalDirection, bool jumpPressed)
    {
        if(_playerHealth.Dead)
        {
            return;
        }

        if(jumpPressed && _touchedGround)
        {
            Jump();
        }

        if(Mathf.Abs(horizontalDirection) > 0.01f)
        {
            HorizontalMove(horizontalDirection);
        } 

        if (_isJumping)
        {
            SetJumpAnimation();
        }

        if (Mathf.Abs(horizontalDirection) < 0.01f || _isJumping || !_touchedGround)
        {
            _playerAnimator.SetBool("IsRunning", false);
        }
    }

    private void Jump()
    {
        _isJumping = true;

        _playerRB2D.velocity = new Vector2(_playerRB2D.velocity.x, jumpForce);
    }

    private void SetJumpAnimation()
    {
        if(_playerRB2D.velocity.y > 0)
        {
            _playerAnimator.SetBool("IsJumping", true);

            return;
        }

        if (_playerRB2D.velocity.y < 0)
        {
            _playerAnimator.SetBool("IsJumping", false);
            _playerAnimator.SetBool("IsFalling", true);

            return;
        }

        if (_touchedGround)
        {
            _playerAnimator.SetBool("IsJumping", false);
            _playerAnimator.SetBool("IsFalling", false);

            _isJumping = false; 
        }
    }

    private void HorizontalMove(float direction)
    {
        _playerRB2D.velocity = new Vector2(curve.Evaluate(direction), _playerRB2D.velocity.y);

        if(!_isJumping && _touchedGround)
        {
            _playerAnimator.SetBool("IsRunning", true);
        }

        // If the input is moving the player right and the player is facing left...
        if (direction > 0 && !_facingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (direction < 0 && _facingRight)
        {
            // ... flip the player.
            Flip();
        }
    }


    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(groundColliderTransform.position, jumpOffsetRadius);
    }
}
