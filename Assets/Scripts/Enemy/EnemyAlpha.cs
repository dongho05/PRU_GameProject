using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAlpha : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public Slider healthBar;
    public int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    // Update is called once per frame
    public void TakeHitDamageAlpha(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CharacterMovement playerHealth = collision.gameObject.GetComponent<CharacterMovement>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
            //Debug.Log("-5 red");
        }
       
    }
}
