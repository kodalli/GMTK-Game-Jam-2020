using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    // private int maxHealth = 100;
    public int health = 100;

    public void TakeDamage(int damage)
    {

            health -= damage;

            if (health <= 0)
            {
                Die();
            }
  
    }
    public void Heal(int heart)
    {
        //if(health < maxHealth)
        health += heart;
    }
    void Die()
    {
        // Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
        
}
