using UnityEngine;
using UnityEngine.SceneManagement;

public class moemvment3 : MonoBehaviour

{
    
    [SerializeField]
    public int sanity = 100;
    public float moveSpeed = 5f; // movement speed
    public float jumpForce = 5f; // how high you jump
    public Transform groundCheck; // checks if you're on the ground 
    public float groundCheckRadius = 0.2f; // groundcheck hitbox
    public LayerMask groundLayer; // whether the groundchecks sees it as ground or not
    private bool isFacingRight = true; // checks what direction the player is facing
    private bool isGrounded = false; // in case we are on the ground or not
    private Rigidbody2D rb; // rigidbody
    //private Animator animator; // animating

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // grabs the rigidobdy
        //animator = GetComponent<Animator>(); // grabs the animator
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Kolla om spelaren �r p� marken
        float moveDirection = Input.GetAxis("Horizontal");  // checks if we moev horizontally
        Move(moveDirection);
        //if (moveDirection > 0 && !isFacingRight) // Flippa spelaren s� den tittar i den riktningen som den r�r sig i
        //{
            //Flip();
        //}
        //else if (moveDirection < 0 && isFacingRight) // Flippa spelaren s� den tittar i den riktningen som den r�r sig i
        //{
            //Flip();
        //}
        
        //GREEN ABOVE WILL FIX EVENTUALLY. PLACEHOLDER
        
        
        
        if (Input.GetButtonDown("Jump") && isGrounded) // If space is pressed, then jump
        {
            Jump();
        
        }
        //animator.SetBool("Jump", !isGrounded); PLACEHOLDER
    }
    private void Move(float direction)
    {
        Vector2 movement = new Vector2(direction * moveSpeed, rb.linearVelocity.y); // how we move
        rb.linearVelocity = movement;
        float absoluteSpeed = Mathf.Abs(direction * moveSpeed);
        //animator.SetFloat("Speed", absoluteSpeed); // speed for the animation
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // jumps upwards
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;  // Flippa player spriten horisontellt
        transform.Rotate(0f, 180f, 0f);
        Transform firepoint = transform.Find("FirePoint");
        firepoint.localPosition = new Vector3(-firepoint.localPosition.x, firepoint.localPosition.y, firepoint.localPosition.z);
    }
  
    
}

