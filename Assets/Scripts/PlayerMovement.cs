﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private bool isJumping = false;

    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJump = 150f;
    // [SerializeField] private float decayRate = 0.1f;
    float maxJumpTime = 0.4f;
    float jumpTimeCounter;
    float jumpCooldown;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jumpCooldown = -1f;
    }

    void Update()
    {
        float jumpValue = Input.GetAxis("Jump");
        if(!isJumping && jumpValue > 0.5f && jumpCooldown < 0f)
        {
            animator.SetBool("Jumping", true);
            jumpCooldown = 0.5f;
            rb.AddForce(transform.up * lowJump);
            isJumping = true;
            jumpTimeCounter = maxJumpTime;

        }
        else if (isJumping && jumpValue > 0.5f) {
            if (jumpTimeCounter > 0) {
                rb.AddForce(transform.up * jumpForce);
                jumpTimeCounter -= Time.deltaTime;
                // Debug.Log(jumpTimeCounter);
            } 
        }
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            animator.SetBool("Jumping", false);
        }
        jumpCooldown -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isJumping = false;
        if (other.gameObject.tag == "Obstacle") {
            SceneManager.LoadScene(0);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // died
    //    if (collision.gameObject.tag == "Obstacle") {
    //        SceneManager.LoadScene(0);
    //    }
    //}

    //private IEnumerator JumpCountDown()
    //{
    //    yield return new WaitForSeconds(0.2f);
    //}

}
