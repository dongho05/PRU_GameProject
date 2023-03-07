using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.AxisState;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Joystick joystickMovement;


    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;


    public Slider healthSlider;
    public float startingHealth;
    public float currentHealth;

    public Transform firePoint;
    public GameObject bulletPrefab;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = startingHealth;
        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.x = joystickMovement.joystickVec.x;
        movement.y = joystickMovement.joystickVec.y;


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }

        //Move 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
    }

    public void Health(float amount)
    {
        currentHealth += amount;
        UpdateHealthBar();
    }

}
