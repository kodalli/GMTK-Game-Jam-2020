using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public int health = 100;
    // public GameObject deathEffect;
    // Start is called before the first frame update

    public void TakeDamage(int damage)
    {

            health -= damage;

            if (health <= 0)
            {
                Die();
            }
  
    }
    void Die()
    {
        // Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
        
}
