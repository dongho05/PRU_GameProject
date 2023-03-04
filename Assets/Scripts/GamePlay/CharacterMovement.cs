using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    public Slider healthSlider;
    public float startingHealth = 10f;
    public float currentHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startingHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos =  cam.ScreenToWorldPoint(Input.mousePosition);


    }

     void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if(currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    void UpdateHealthBar()
    { 
        healthSlider.value = currentHealth;
    }


}
