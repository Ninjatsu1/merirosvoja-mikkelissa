using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public float MovementSpeed = 1;
    private Rigidbody2D MyRigidbody2D;
    public float jumpForce = 1;
    public bool facingRight;

    private Animator anim;

    public int score = 0;
    public TMP_Text ScoreText;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisGround;
    void Start()
    {
        facingRight = true;
        MyRigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        ScoreText.GetComponent<TMP_Text>().text = "x " + score.ToString("0");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisGround);

        // float horizontal is Running
        float Horizontal = Input.GetAxis("Horizontal"); //Finds input from the input manager
        transform.position += new Vector3(Horizontal, 0, 0) * Time.deltaTime * MovementSpeed;
        if (isGrounded == true && Input.GetButtonDown("Jump") && Mathf.Abs(MyRigidbody2D.velocity.y) < 0.001f)
        {
            //triggers the jump
            anim.SetTrigger("takeOf");
            MyRigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            //endJump

            anim.SetBool("isJumping", true);

        }

        if (Horizontal == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);

        }
        flip(Horizontal);
    }
    void flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1; //Kerrotaan miinus luvulla. Skaala saa negatiivisen arvon ja flippaa pelaaja ukkelin.
            transform.localScale = theScale;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Equals("vene"))
        {
            this.transform.parent = other.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name.Equals("vene"))
        {
            this.transform.parent = null;
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Health.health = data.health;
        Health.numOfHearts = data.numOfHearts;
    }


}
