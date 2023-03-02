using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;

    private GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Character");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, character.transform.position);
        if (distance < 7)
        {
            timer += Time.deltaTime;
            if (timer > 1.5)
            {
                timer = 0;
                shoot();
            }
        }

    }

    private void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
