using UnityEngine;


public class Bullet : MonoBehaviour
{
    private float speed = 9f;
    private Vector3 dir;
    private Vector3 firePoint;
    private int dame = 1;

    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        firePoint = GameObject.Find("FirePoint").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        if (transform.position.x - firePoint.x > 30 || transform.position.y - firePoint.y > 30)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<EnemyRangeActionScript>();
        var enemyDelta = other.GetComponent<EnemyDelta>();
        var enemyAlpha = other.GetComponent<EnemyAlpha>();
        var enemyBoss = other.GetComponent<EnemyBoss>();
        
        if (enemy)
        {
               
            enemy.TakeHit(dame);
            Destroy(gameObject);
        }
        else if (enemyDelta)
        {
            enemyDelta.TakeHitDamageDelta(dame);
            Destroy(gameObject);
        }
        else if (enemyAlpha)
        {
            enemyAlpha.TakeHitDamageAlpha(dame);
            Destroy(gameObject);
        }

        else if(enemyBoss)
        {
            enemyBoss.TakeHitDamageAlpha(dame);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        


    }
}
