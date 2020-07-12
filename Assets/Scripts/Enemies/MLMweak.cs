using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLMweak : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject explosion;
    private int damage = 25;
    void Start()
    {
        StartCoroutine(Kill());
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Karen" || collision.gameObject.tag == "Enemy")
        {
            Die();
        }

        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
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
        Die();
        
    }
}
