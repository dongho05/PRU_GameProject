using UnityEngine;

public class ScaleOverTime : MonoBehaviour
{
    private float speed = 9f;
    private Vector3 dir;
    private Vector3 firePoint;

    public float scaleSpd;
    public float minScale, maxScale;
    Vector2 scale;
    // Start is called before the first frame update
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        firePoint = GameObject.Find("FirePoint").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
        if (transform.position.x - firePoint.x > 30 || transform.position.y - firePoint.y > 30)
        {
            Destroy(gameObject);
        }

        scale = new Vector2(Mathf.Clamp(scale.x += scaleSpd * Time.deltaTime, minScale, maxScale), scale.y);
        scale = new Vector2(scale.x, Mathf.Clamp(scale.y += scaleSpd * Time.deltaTime, minScale, maxScale));
        transform.localScale = scale;
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
