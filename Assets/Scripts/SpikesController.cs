using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesController : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    void Start()
    {
        StartCoroutine(Killself());
    }

    // Update is called once per frame
    private IEnumerator Killself()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    public void Die()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);

    }
}