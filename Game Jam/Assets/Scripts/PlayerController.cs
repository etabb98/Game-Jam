using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    //private Animator playerAnim; //calls animator type

    public Projectile Snow;
    public Transform ShootRange;

    public int runSpeed;
    public float JumpForce = 12;
    public float gravityModifier = 1;

    public bool isGrounded = false;
    public bool gameOver = false;

    private BoxCollider2D boxCollider2D;

    public Transform groundCheck;
    public LayerMask groundMask;

    public Vector2 initialPos;
    public Transform pushBack;



    void Awake()
    {
        initialPos = transform.position; //saves position
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>(); //whats placed between <> is the component you want to get

       
        //playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Jump();
    }

    private void PlayerMove()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector2(moveHorizontal * runSpeed, playerRb.velocity.y);

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundMask);
    }
    private void Jump() { 
          if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            //isGrounded = false;
            Debug.Log("Jump works");
            //playerAnim.SetTrigger("Jump_trig"); //Activates trigger named "Jump_trig"
        }
    
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Debug.Log("shoot");
            Instantiate(Snow, ShootRange.position, transform.rotation);

        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        {
            Debug.Log(" works");
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            playerRb.transform.parent = collision.gameObject.transform;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit");
            //playerRb.position = Vector2.MoveTowards(transform.position, pushBack, ;
            transform.position = initialPos; //moves object to initial pos
        }

    }

    

void OnCollisionExit2D(Collision2D done)
    {
        Debug.Log(" up");
        isGrounded = false;

        if (done.gameObject.tag == "Platform")
        {
            playerRb.transform.parent = null; //stops player from moving with platform once it jumps off
        }
    }

   


}
