using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceForce : MonoBehaviour
{
    public int damage = 30;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        if(hitInfo.tag == "Player")
        {
            Destroy(gameObject);
        }
            
        Health health = hitInfo.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(50);
            
        }
    }
}
