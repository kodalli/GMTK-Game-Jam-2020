using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    [SerializeField] private int damage = 25;
    [SerializeField] private GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Kill());
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        if (hitInfo.tag == "Player" || hitInfo.tag == "Karen")
        {
            Die();
        }

        Health health = hitInfo.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(5f);
        Die();
    }

    public void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
