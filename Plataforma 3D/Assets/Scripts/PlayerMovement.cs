using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Animator anim;

    private bool andando = false;
    private bool pulando = false;

    //Movimentação do personagem
    private Vector2 input;
    [SerializeField] private float moveSpeed;
    private Vector3 moveDirection;
    [SerializeField] private float jumpPower;

    //Gravidade
    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3f;
    private float velocity;

    //Rotacionar o personagem
    [SerializeField] private float smoothTime = 0.05f;
    private float currentVelocity;

    // Knockback
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    private float knockbackCounter;

    //Coyote Time
    [SerializeField] private float coyoteTime = 0.25f;
    [SerializeField] private float coyoteTimeCounter;

    //Jump Buffer
    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (IsGrounded() && velocity < 0f)
        {

            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(velocity > -1f)
        {
            anim.SetBool("Pulando", pulando = true);
            anim.SetBool("Andar", andando = false);
        }

        else if (input.x == 0 && input.y == 0)
        {
            anim.SetBool("Andar", andando = false);
            anim.SetBool("Pulando", pulando = false);
        }

        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
    }

    public void ApplyGravity()
    {
        
        if (IsGrounded() && velocity < 0f)
        {
            velocity = -1f;
        }
        else
        {
            velocity += gravity * gravityMultiplier * Time.deltaTime;
        }

        moveDirection.y = velocity;
    }

    public void ApplyRotation()
    {
        if (input.sqrMagnitude == 0) return;
        var targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public void ApplyMovement()
    {
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        moveDirection = new Vector3(input.x, 0f, input.y);
        anim.SetBool("Andar", andando = true);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && coyoteTimeCounter < 0) return;
        
        
        velocity += jumpPower;
        coyoteTimeCounter = 0f;
    }

    public bool IsGrounded() => characterController.isGrounded;

    public void Knockback(Vector3 direction)
    {
        //knockbackCounter = knockbackTime;

        //moveDirection = direction * knockbackForce;

        velocity += knockbackForce;
    }
}
