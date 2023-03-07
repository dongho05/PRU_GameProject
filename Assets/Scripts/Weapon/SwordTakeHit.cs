using UnityEngine;

public class SwordTakeHit : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.collider.GetComponent<EnemyRangeActionScript>();
            var enemyDelta = collision.collider.GetComponent<EnemyDelta>();
            var enemyAlpha = collision.collider.GetComponent<EnemyAlpha>();
            if (enemy)
            {
                enemy.TakeHit(1);
            }
            else if (enemyDelta)
            {
                enemyDelta.TakeHitDamageDelta(2);
            }
            else if (enemyAlpha)
            {
                enemyAlpha.TakeHitDamageAlpha(1);
            }
        }

    }
}
