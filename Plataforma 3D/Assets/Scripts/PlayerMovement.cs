using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Animator anim;

    //Sound Effects
    [SerializeField] AudioSource pulo;
    [SerializeField] AudioSource attack;
    [SerializeField] AudioSource sofrerDano;

    //[SerializeField] GameObject Mimir;

    private bool andando = false;
    private bool pulando = false;
    private bool caindo = false;
    private bool atacando = false;
    private bool tomandoDano = false;

    //Movimentação do personagem
    private Vector2 input;
    [SerializeField] private float moveSpeed;
    private Vector3 moveDirection;
    [SerializeField] private float jumpPower;

    //Gravidade
    private float gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3f;
    public float velocity;

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

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Atacar", atacando = true);
            attack.Play();
            anim.SetBool("Cair", caindo = false);
            anim.SetBool("Andar", andando = false);
            anim.SetBool("Pulando", pulando = false);
            anim.SetBool("ReceberDano", tomandoDano = false);
        }

        if (velocity < 0f && !IsGrounded())
        {
            anim.SetBool("Atacar", atacando = false);
            anim.SetBool("Cair", caindo = true);
            anim.SetBool("Andar", andando = false);
            anim.SetBool("Pulando", pulando = false);
            anim.SetBool("ReceberDano", tomandoDano = false);
        }
        

        if ((input.x != 0 || input.y != 0) && IsGrounded() && Input.GetMouseButtonDown(0) == false)
        {
            anim.SetBool("Andar", andando = true);
            anim.SetBool("Cair", caindo = false);
            anim.SetBool("Pulando", pulando = false);
            anim.SetBool("Atacar", atacando = false);
            anim.SetBool("ReceberDano", tomandoDano = false);
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Cair", caindo = false);
            anim.SetBool("Pulando", pulando = true);
            anim.SetBool("Andar", andando = false);
            anim.SetBool("Atacar", atacando = false);
            anim.SetBool("ReceberDano", tomandoDano = false);

        }
        else if (input.x == 0 && input.y == 0 && IsGrounded() && Input.GetMouseButtonDown(0) == false)
        {
            anim.SetBool("Atacar", atacando = false);
            anim.SetBool("Cair", caindo = false);
            anim.SetBool("Andar", andando = false);
            anim.SetBool("Pulando", pulando = false);
            anim.SetBool("ReceberDano", tomandoDano = false);
        }
        else if (IsGrounded())
        {
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
        //anim.SetBool("Andar", andando = true);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && coyoteTimeCounter < 0) return;
        pulo.Play();
        
        velocity += jumpPower;
        coyoteTimeCounter = 0f;
    }

    public bool IsGrounded() => characterController.isGrounded;

    public void Knockback(Vector3 direction)
    {
        anim.SetBool("ReceberDano", tomandoDano = true);
        anim.SetBool("Cair", caindo = false);
        anim.SetBool("Pulando", pulando = false);
        anim.SetBool("Andar", andando = false);
        anim.SetBool("Atacar", atacando = false);
        
        velocity += knockbackForce;
        sofrerDano.Play();
    }
}
