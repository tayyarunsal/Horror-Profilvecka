using UnityEngine;

public class Playr : MonoBehaviour
{
    [SerializeField]
    public float speed = 3f;
    [SerializeField]
    KeyCode jump = KeyCode.Space;
    [SerializeField]
    KeyCode crouch = KeyCode.S;
    [SerializeField]
    KeyCode left = KeyCode.A;
    [SerializeField]
    KeyCode right = KeyCode.D;
    [SerializeField]
    public int sanity = 100;
    [SerializeField]
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public Transform groundCheck;
    [SerializeField]
    public float groundCheckRadius = 0.2f;
    private bool isFacingRight = true;
    private bool isGrounded = false;
    public LayerMask groundLayer;
    private Animator animator;




    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Makes it jump
     
    }


    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Kolla om spelaren �r p� marken
        float moveDirection = Input.GetAxis("Horizontal");  // Kolla om vi r�r oss horisontellt
        Move(moveDirection); // Flytta spelaren
        if (moveDirection > 0 && !isFacingRight) // Flippa spelaren s� den tittar i den riktningen som den r�r sig i
        {
            Flip();
        }
        else if (moveDirection < 0 && isFacingRight) // Flippa spelaren s� den tittar i den riktningen som den r�r sig i
        {
            Flip();
        }
        if (Input.GetButtonDown("Jump") && isGrounded) // Om vi tycker p� space, s� l�t spelaren hoppa
        {
            Jump();
        }
        animator.SetBool("Jump", !isGrounded);

        if (Input.GetKey(jump)) //MAKE THE JUMP ACTUALLY JUMP
        {
            
        }
        else if (Input.GetKey(crouch))
        {
            transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime; //REMOVE AND MAKE IT CROUCH
        }
        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(right))
        {
            transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }


        if (sanity < 0)
        { //FILL

        }

    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;  // 
        transform.Rotate(0f, 180f, 0f);
        Transform firepoint = transform.Find("FirePoint");
        firepoint.localPosition = new Vector3(-firepoint.localPosition.x, firepoint.localPosition.y, firepoint.localPosition.z);
    }


    private void Move(float direction)
         {
        Vector2 movement = new Vector2(direction * speed, rb.linearVelocity.y); // r�kna ut hur vi r�r oss i relation till spelarens velocity
        rb.linearVelocity = movement;
        float absoluteSpeed = Mathf.Abs(direction * speed);
        animator.SetFloat("Speed", absoluteSpeed); // Använd Speed parametern i animatorn
    





      

         }
}

