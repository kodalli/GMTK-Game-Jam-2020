using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KarenController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float chaseOffsetSpeed = 0.7f;
    private GameObject player;
    private Rigidbody2D rb;
    private float jumpForce = 10f;
    private float fallMultiplier = 2.5f;
    private float minDistance = 15f;
    private float distToPlayer;
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
        chaseOffsetSpeed = distToPlayer > minDistance ? 2f : 1f;
        rb.velocity = new Vector2(((player.transform.position - rb.transform.position).normalized * (chaseOffsetSpeed + player.GetComponent<Rigidbody2D>().velocity.x)).x, rb.velocity.y);
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        if (distToPlayer < 1.7f)
            Die();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("hit");
        switch (collision.gameObject.tag) {
            case ("obstacle"):
                StartCoroutine(Timer());
                break;
            case ("Enemy"):
                Destroy(collision.gameObject);
                break;
        }
    }

    private IEnumerator Timer()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
    }
    private void Die()
    {
        SceneManager.LoadScene(0);
    }
}
