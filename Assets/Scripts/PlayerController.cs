using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float ranSpeed = 8f;
    public float CurrentMoveSpeed
    {
        get
        {
            if (IsMoving)
            {
                if (IsRunning)
                {
                    return ranSpeed;
                } else
                {
                    return walkSpeed;
                }
            } else
            {
                return 0;
            }
        }
    }
    Vector2 moveInput;
    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }
    [SerializeField]
    private bool _isRunning = false;
    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }

    public bool IsFacingRight { get 
        { 
            return _isFacingRight; 
        } private set 
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            };
            _isFacingRight = value;
        } 
    }
    public bool _isFacingRight = true;

    Rigidbody2D rb;
    Animator animator;

    private void Awake()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Move the player
        rb.linearVelocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.linearVelocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Get the value of the input
        moveInput = context.ReadValue<Vector2>();
        // Move the player
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
            walkSpeed *= 2;
        }
        else if (context.canceled)
        {
            IsRunning = false;
            walkSpeed /= 2;
        }
    }
}
