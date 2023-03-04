using UnityEditor.Build.Player;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    Transform character;
    private Rigidbody2D rb;
    public float speed = 5;
    public float damage = 10f;
    //public float force;
    //private float timer;
    // Start is called before the first frame update
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    character = GameObject.FindGameObjectWithTag("Character");

    //    Vector3 direction = character.transform.position - transform.position;
    //    rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

    //    float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (timer > 10)
    //    {
    //        Destroy(gameObject);
    //    }
    //}


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        character = GameObject.FindGameObjectWithTag("Character").transform;
        Vector2 move = (character.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(move.x, move.y);
        Destroy(this.gameObject, 2);
    }
    //void Update()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, character.position, speed * Time.deltaTime);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CharacterMovement playerHealth = collision.gameObject.GetComponent<CharacterMovement>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
    
}
