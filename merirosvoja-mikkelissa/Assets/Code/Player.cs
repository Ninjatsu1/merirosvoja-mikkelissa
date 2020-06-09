﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovementSpeed = 1;
    private Rigidbody2D MyRigidbody2D;
    public float jumpForce = 1;
    public bool facingRight;
     void Start()
    {
        facingRight = true;
        MyRigidbody2D = GetComponent<Rigidbody2D>();
    }
     void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal"); //Finds input from the input manager
        transform.position += new Vector3(Horizontal, 0, 0) * Time.deltaTime * MovementSpeed;
        if (Input.GetButtonDown("Jump") && Mathf.Abs(MyRigidbody2D.velocity.y) < 0.001f)
        {
            MyRigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

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
}