using UnityEngine;
using UnityEngine.UI;

public class EnemyRangeActionScript : MonoBehaviour
{
    public float speed;
    public float lineOfSite;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform character;

    public int maxHealth = 4;
    private int currentHealth;
    public Slider healthBar;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Character").transform;
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        Debug.Log("EnemyCircle: " + currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(character.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, character.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.up, lineOfSite);
        Gizmos.DrawWireSphere(transform.up, shootingRange);
    }

    public void TakeHit(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;
        Debug.Log("EnemyCircle: " + currentHealth);
        if (currentHealth <= 0)
        {
            score += 3;
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddPoints(score);
            Destroy(gameObject);
        }
    }
}
