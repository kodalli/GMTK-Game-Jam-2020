using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{
    private bool dead = false;
    private int maxHealth = 100;
    public int health = 100;
    [SerializeField] private GameObject explosion;
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
        if(health < maxHealth)
            health += heart;
    }
    public void Die()
    {
        if(!dead)
            StartCoroutine(Death());
    }
    private IEnumerator Death()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        // Debug.Log("die");
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
    }
        
}
