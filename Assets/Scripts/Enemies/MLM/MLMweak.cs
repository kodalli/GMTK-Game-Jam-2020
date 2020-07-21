using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLMweak : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject explosion;
    [SerializeField] private AudioSource audioData;
    void Start()
    {
        StartCoroutine(Kill());
        audioData.GetComponent<AudioSource>();
        audioData.Play(0);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Karen" || collision.gameObject.tag == "Enemy")
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
        Die();
        
    }
}
