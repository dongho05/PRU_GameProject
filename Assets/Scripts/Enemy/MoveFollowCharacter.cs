using UnityEngine;

public class MoveFollowCharacter : MonoBehaviour
{
    //public GameObject character;
    public float speed;
    private float distance = 1.5f;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        //    Vector2 direction = character.transform.position - transform.position;
        //    direction.Normalize();
        //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //    transform.position = Vector2.MoveTowards(this.transform.position, character.transform.position, speed * Time.deltaTime);
        //    transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        target = GameObject.FindGameObjectWithTag("Character").transform;
        if (distance < 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
