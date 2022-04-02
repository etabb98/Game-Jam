using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Rigidbody2D IcePrin;

    public float runSpeed = 5;
    public float JumpForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        IcePrin = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        IcePrin.velocity = new Vector2(moveHorizontal * runSpeed, IcePrin.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IcePrin.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            //isGrounded = false;
            Debug.Log("Jump works");
            //playerAnim.SetTrigger("Jump_trig"); //Activates trigger named "Jump_trig"
        }
    }

}
