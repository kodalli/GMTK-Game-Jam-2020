using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnyBladeController : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Start()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime);
        rb.velocity = new Vector2(-3f, 0f);
    }
}
