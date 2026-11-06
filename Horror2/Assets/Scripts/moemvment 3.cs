using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moemvment3 : MonoBehaviour

{
    public bool dead;
    public float moveSpeed = 5f; // movement speed
    public float jumpForce = 5f; // how high you jump
    public Transform groundCheck; // checks if you're on the ground 
    public float groundCheckRadius = 0.01f; // groundcheck hitbox, the lesser the number the harder it gets to spam it to hover
    public LayerMask groundLayer; // whether the groundchecks sees it as ground or not
    private bool isFacingRight = true; // checks what direction the player is facing
    private bool isGrounded = false; // in case we are on the ground or not
    private Rigidbody2D rb; // rigidbody
    private Animator animator; // animating
    private SanitySystem sanitySystem;
    private EyeClosing eyeClosing;
    private bool blunda;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // grabs the rigidobdy
        sanitySystem = GetComponentInChildren<SanitySystem>();
        animator = GetComponent<Animator>(); // grabs the animator
        eyeClosing = GetComponentInChildren<EyeClosing>();
        blunda = true == eyeClosing.blunda == true;
    }
    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Checks if the player is on the ground
        float moveDirection = Input.GetAxis("Horizontal");  // checks if we move horizontally
        Move(moveDirection);
        if (moveDirection > 0 && !isFacingRight) //  Flips the player to the direction they're moving in
        {
            Flip();
        }
        else if (moveDirection < 0 && isFacingRight) // Flips the player to the direction they're moving in
        {
            Flip();
        }



        if (Input.GetButtonDown("Jump") && isGrounded) // If space is pressed, then jump
        {
            Jump();

        }
        if (eyeClosing.blunda == true)
        {
            blunda = true;
            animator.SetBool("Blunda", blunda); //for some reason the animation only decides to use one frame and since we have very little time left I will be forced to ignore this problem
           
        } //if you want to view the full animations, check the sprites: eye-close 1-7 and gameover 1-10
       
        if (dead == true)
        { 
        animator.SetBool("Dead", dead); //same singular frame issue with this as well, I suspect it has something to do with using variables from different scripts.
            moveSpeed = 0f;
            jumpForce = 0f;
        }

        if (sanitySystem.sanity <= 0f)
        { dead = true;
            moveSpeed = 0f;
            jumpForce = 0f;
        }
        

    }
    private void Move(float direction)
    {
        Vector2 movement = new Vector2(direction * moveSpeed, rb.linearVelocity.y); // how we move
        rb.linearVelocity = movement;
        float absoluteSpeed = Mathf.Abs(direction * moveSpeed);
        animator.SetFloat("Speed", absoluteSpeed); // speed for the animation
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // jumps upwards
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;  // flips the player sprite
        transform.Rotate(0f, 180f, 0f);
        Transform firepoint = transform.Find("FirePoint");
        firepoint.localPosition = new Vector3(-firepoint.localPosition.x, firepoint.localPosition.y, firepoint.localPosition.z);
    }

}

