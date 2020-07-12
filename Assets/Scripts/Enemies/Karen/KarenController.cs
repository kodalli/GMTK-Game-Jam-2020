using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KarenController : MonoBehaviour
{
    // Start is called before the first frame update
    private float chaseOffsetSpeed = 0.2f;
    private GameObject player;
    private Rigidbody2D rb;
    private float jumpForce = 10f;
    private float fallMultiplier = 2.5f;
    private float minDistance = 10f;
    private float distToPlayer;
    private bool isJumping = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distToPlayer = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(distToPlayer);
        chaseOffsetSpeed = distToPlayer > minDistance ? 5f : 0.5f;
        rb.velocity = new Vector2(((player.transform.position - rb.transform.position).normalized * (chaseOffsetSpeed + player.GetComponent<Rigidbody2D>().velocity.x)).x, rb.velocity.y);
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (distToPlayer < 1.7f)
            player.GetComponent<Health>().Die();
        else if (distToPlayer > 20f)
            transform.position = new Vector2(Camera.main.transform.position.x-15f, Camera.main.transform.position.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "obstacle" && !isJumping) {
            StartCoroutine(Timer());
            isJumping = true;
        }
    }

    private IEnumerator Timer()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        isJumping = false;
    }
}
