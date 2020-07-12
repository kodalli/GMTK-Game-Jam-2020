using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartForce : MonoBehaviour
{
    private int healPlayer = 25;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        if (hitInfo.tag == "Player") {
            Health health = hitInfo.GetComponent<Health>();
            if (health != null) {
                health.Heal(healPlayer);
            }
            Die();

        }
    }
    public void Die()
    {
        Destroy(gameObject);

    }
}

