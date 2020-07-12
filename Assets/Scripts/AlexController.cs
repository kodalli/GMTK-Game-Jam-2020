using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexController : MonoBehaviour
{
    [SerializeField] private int damage = 25;
    [SerializeField] private GameObject explosion;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        // hitInfo.tag == "Player" || 
        if (hitInfo.gameObject.CompareTag("Karen"))
        {
            Die();
        }
        else if (hitInfo.gameObject.tag == "Player")
        {
            Health health = hitInfo.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
    public void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}
