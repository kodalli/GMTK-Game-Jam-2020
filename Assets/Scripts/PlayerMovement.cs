using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float jumpValue = Input.GetAxis("Jump");
        if(!isJumping && jumpValue > 0.5f)
        {
            rb.AddForce(transform.up * lowJump);
            // StartCoroutine(JumpCountDown());
            isJumping = true;
            jumpTimeCounter = maxJumpTime;

        }
        if (isJumping && jumpValue > 0.5f) {
            if (jumpTimeCounter > 0) {
                rb.AddForce(transform.up * jumpForce);
                jumpTimeCounter -= Time.deltaTime;
                Debug.Log(jumpTimeCounter);
            } 
        }
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isJumping = false;
    }

    //private IEnumerator JumpCountDown()
    //{
    //    //the initial jump
    //    rb.AddForce(Vector2.up * jumpForce);
    //    yield return null;

    //    //can be any value, maybe this is a start ascending force, up to you
    //    // float currentForce = lowJump;
    //    float timer = 0f;
    //    float maxTime = 0.2f;
    //    bool jumpExtended = false;
    //    while (Input.GetKey(KeyCode.Space)) {
    //        if(timer > maxTime && !jumpExtended) {
    //            rb.AddForce(Vector2.up * lowJump);
    //            jumpExtended = true;
    //            //currentForce -= decayRate * Time.deltaTime;
    //        }
    //        timer += Time.deltaTime;
    //        yield return null;
    //    }
    //}
}
