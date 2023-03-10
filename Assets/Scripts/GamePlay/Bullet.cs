using UnityEngine;


public class Bullet : MonoBehaviour
{
    private float speed = 9f;
    private Vector3 dir;
    private Vector3 firePoint;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyRangeActionScript>();
        var enemyDelta = collision.collider.GetComponent<EnemyDelta>();
        var enemyAlpha = collision.collider.GetComponent<EnemyAlpha>();
        if (enemy)
        {
            enemy.TakeHit(1);
            Destroy(gameObject);
        }
        else if (enemyDelta)
        {
            enemyDelta.TakeHitDamageDelta(2);
            Destroy(gameObject);
        }
        else if (enemyAlpha)
        {
            enemyAlpha.TakeHitDamageAlpha(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }



    }
}
