using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float chaseOffsetSpeed = 0.3f;
    private GameObject player;
    private Rigidbody2D rb;
    private float jumpForce = 7f;
    private float fallMultiplier = 2.5f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(((player.transform.position - rb.transform.position).normalized * (chaseOffsetSpeed + player.GetComponent<Rigidbody2D>().velocity.x)).x, rb.velocity.y);
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //if(collision.gameObject.tag == "Obstacle") {
    //    //    rb.AddForce(transform.up * jumpForce);
    //    //}
    //    rb.AddForce(transform.up * jumpForce);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if(collision.gameObject.tag == "obstacle")
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
}
