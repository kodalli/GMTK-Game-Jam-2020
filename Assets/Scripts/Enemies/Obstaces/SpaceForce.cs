using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceForce : MonoBehaviour
{
    private int damage = 25;
    [SerializeField] private GameObject explosion;

    void Start()
    {
        StartCoroutine(Kill());
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        if(hitInfo.tag == "Player") 
        {
            Health health = hitInfo.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Die();
        }
        else if (hitInfo.tag == "Karen" || hitInfo.tag == "obstacle")
        {
            Die();
        }



    }
    public void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);

    }
    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
