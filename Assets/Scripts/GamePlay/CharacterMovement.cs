using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Joystick joystickMovement;


    public Rigidbody2D rb;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;


    public Slider healthSlider;
    public int startingHealth = 100;
    public int currentHealth;

    public Transform firePoint;
    //public GameObject bulletPrefab;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = startingHealth;
        healthSlider.maxValue = startingHealth;
        healthSlider.value = currentHealth;
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


    public void TakeDamage(int damage)
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
        Debug.Log("Player: " + currentHealth);
    }

    public void Health(int amount)
    {
        if (currentHealth + amount > 100)
        {
            currentHealth = 100;
        }
        else
        {
            currentHealth += amount;
        }
        UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUpItems"))
        {
            Destroy(other.gameObject);
        }

    }
}
