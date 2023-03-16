using UnityEngine;
using UnityEngine.UI;

public class EnemyAlpha : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    public Slider healthBar;
    public int damage = 1;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        Debug.Log("EnemyAlpha: " + currentHealth);
    }

    // Update is called once per frame
    public void TakeHitDamageAlpha(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        Debug.Log("EnemyAlpha: " + currentHealth);
        if (currentHealth <= 0)
        {
            score += 3;
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddPoints(score);
            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CharacterMovement playerHealth = collision.gameObject.GetComponent<CharacterMovement>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            //Destroy(gameObject);
            //Debug.Log("-5 red");
        }

    }
}
