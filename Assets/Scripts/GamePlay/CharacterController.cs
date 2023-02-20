using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public int dir = 0;
    Vector2 movement;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        move();
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    //void FixedUpdate()
    //{
    //    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    //}



    void move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        transform.position += new Vector3(horizontal * Time.deltaTime * moveSpeed, vertical * Time.deltaTime * moveSpeed, 0);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (horizontal > 0 && dir == 1)
        {
            transform.Rotate(0, 180f, 0);
            dir = 0;

        }
        else if (horizontal < 0 && dir==0)
        {
            transform.Rotate(0, 180f, 0);
            dir = 1;
        }
    }


}
