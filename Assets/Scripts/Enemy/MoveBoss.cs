
using UnityEngine;

public class MoveBoss : MonoBehaviour
{

    //public GameObject character;
    public float speed;
    private float distance = 0.5f;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
