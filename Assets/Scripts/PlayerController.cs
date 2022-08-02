using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private bool preparingJump = false;
    private bool isJumping = false;
    private bool isWalking;
    private GameController _gameController;
    private GameControllerInfinity _gameControllerInfinity;
    private LevelController _levelController;


    public AudioSource fxGame;
    public AudioClip fxJump;
    public AudioClip fxStar;

    public Transform groundCheck1;
    public Transform groundCheck2;
    public Transform frontCheck;

    public bool isGrounded;
    public bool facingRight = true;

    public LayerMask groundLayer;

    public float fixedJumpForce = 300;
    private float fixedLeftJumpForce;
    public float jumpForce;
    public float movementSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _gameController = FindObjectOfType<GameController>();
        _gameControllerInfinity = FindObjectOfType<GameControllerInfinity>();
        _levelController = FindObjectOfType<LevelController>();
    }

    void FixedUpdate()
    {
        float x = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        //MOVIMENTAÇÃO
        if (isGrounded && !preparingJump)
        {
            isWalking = true;
            rb.velocity = new Vector2(x * movementSpeed, rb.velocity.y + 0.1f);

        }
        if (rb.velocity.x == 0)
        {
            isWalking = false;

        }
        //flip

        if (facingRight && x < 0 || !facingRight && x > 0)
        {
            Flip();
        }
    }

    void Update()
    {
        if (Physics2D.Linecast(transform.position, groundCheck1.position, groundLayer) || Physics2D.Linecast(transform.position, groundCheck2.position, groundLayer))
        {
            isGrounded = true;
        }
        else
            isGrounded = false;

        if (isGrounded)
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }

        fixedLeftJumpForce = -fixedLeftJumpForce;

        Animations();



        //MECANICA DO PULO

        if (rb.velocity == Vector2.zero)
        {
            if (CrossPlatformInputManager.GetButton("Jump") && isGrounded)
            {
                preparingJump = true;
                isJumping = false;
                if (jumpForce < 1)
                {
                    jumpForce += 1f * Time.deltaTime;
                    preparingJump = true;

                }
            }
            if (CrossPlatformInputManager.GetButtonUp("Jump") && isGrounded)
            {
                preparingJump = false;
                isJumping = true;

                if (facingRight)
                {
                    rb.AddForce(new Vector2(fixedJumpForce * jumpForce * 0.5f, fixedJumpForce * jumpForce));
                    fxGame.PlayOneShot(fxJump);
                    preparingJump = false;

                }
                else
                {
                    rb.AddForce(new Vector2(-fixedJumpForce * jumpForce * 0.5f, fixedJumpForce * jumpForce));
                    fxGame.PlayOneShot(fxJump);
                    preparingJump = false;
                }
                jumpForce = 0;
            }
        }

    }

    void Animations()
    {
        anim.SetBool("preparingJump", preparingJump);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isJumping", isJumping);
        anim.SetBool("isWalking", isWalking);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    void Flip()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "FimFase":
                if (_levelController.faseAtual >= PlayerPrefs.GetInt("FasesPassadas"))
                {
                    PlayerPrefs.SetInt("FasesPassadas", _levelController.faseAtual + 1);
                }
                fxGame.enabled = false;
                _levelController.txtFaseCompletada.enabled = true;
                rb.gravityScale = 0;
                fxGame.PlayOneShot(fxStar);
                Destroy(collision.gameObject);
                _levelController.Invoke("Menu", 4f);
                break;
            case "JumpSpring":
                rb.AddForce(new Vector2(0, 700));
                //rb.velocity = new Vector2(0, rb.velocity.y);
                fxGame.PlayOneShot(fxJump);
                isJumping = true;
                break;
            /*case "GeraNovoMapa":
                _gameControllerInfinity.GeraNovoMapa();
                Destroy(collision.gameObject);
                break;*/
        }
    }

}
