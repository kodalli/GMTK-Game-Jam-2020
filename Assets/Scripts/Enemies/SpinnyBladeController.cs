using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyBladeController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject explosion;
    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime);
        rb.velocity = new Vector2(-3f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.GetComponent<Health>().Die();
        else if (collision.gameObject.tag == "Karen")
            Kill();
    }
    private void Kill()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
