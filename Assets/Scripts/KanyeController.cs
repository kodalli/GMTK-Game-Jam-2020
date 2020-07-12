using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class KanyeController : MonoBehaviour
{
    [SerializeField] private int damage = 25;
    [SerializeField] private GameObject explosion;
    [SerializeField] private AudioSource audioData;
    private float dist;
    void Start()
    {
        audioData.GetComponent<AudioSource>();
        //audioData.Play(0);
    }
    private void FixedUpdate()
    {
        dist = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if(dist < 1f)
        {
            audioData.Play(0);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        // hitInfo.tag == "Player" || 
        if (hitInfo.gameObject.tag == "Karen")
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
