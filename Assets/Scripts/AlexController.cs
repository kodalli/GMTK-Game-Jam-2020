using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexController : MonoBehaviour
{
    [SerializeField] private int damage = 25;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject frog;
    private float force = 15f;
    private float dist;
    private float fireRate = 2f;
    private float timer = -1;
    void Start()
    {
        StartCoroutine(Kill());
    }

    void FixedUpdate()
    {
        dist = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (dist < 10f && timer < 0)
        {
            Attack();
            timer = fireRate;
        }
        timer -= Time.deltaTime;
    }
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
            if (hitInfo.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                Die();
                return;
            }
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

    private void Attack()
    {
        GameObject obj = Instantiate(frog, transform.position, transform.rotation);
        obj.GetComponent<Rigidbody2D>().velocity = (Vector2.left * force);
    }

    private IEnumerator Kill()
    {
        yield return new WaitForSeconds(5f);
        Die();
    }
}
