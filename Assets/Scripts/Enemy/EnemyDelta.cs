using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class EnemyDelta : MonoBehaviour
{
    public int maxHealth = 20;
    private int currentHealth;
    public Slider healthBar;
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        Debug.Log("EnemyDelta: " + currentHealth);
    }

    // Update is called once per frame
    public void TakeHitDamageDelta(int damagePlayer)
    {
        currentHealth -= damagePlayer;
        healthBar.value = currentHealth;
        Debug.Log("EnemyDelta: " + currentHealth);
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
            //Debug.Log("-10 vàng");
        }

    }
}
