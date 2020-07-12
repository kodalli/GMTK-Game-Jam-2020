using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLMStrong : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    void Start()
    {
        StartCoroutine(Kill());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Karen")
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
