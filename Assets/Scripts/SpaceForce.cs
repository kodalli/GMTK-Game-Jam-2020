﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceForce : MonoBehaviour
{
    private int damage = 25;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        if(hitInfo.tag == "Player")
        {
            Die();
        }
            
        Health health = hitInfo.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage); 
        }
    }
    public void Die()
    {
        Destroy(gameObject);

    }
}