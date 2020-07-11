using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float chaseOffsetSpeed = 0.1f;
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 20;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(((player.transform.position - rb.transform.position).normalized * (chaseOffsetSpeed + player.GetComponent<Rigidbody2D>().velocity.x)).x, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.tag == "Obstacle") {
        //    rb.AddForce(transform.up * jumpForce);
        //}
        rb.AddForce(transform.up * jumpForce);
    }
}
