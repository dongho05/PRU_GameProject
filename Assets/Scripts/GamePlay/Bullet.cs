using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        if(transform.position.x - firePoint.x > 30 || transform.position.y - firePoint.y > 30)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
