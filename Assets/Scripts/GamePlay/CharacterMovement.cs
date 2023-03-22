using System;
using System.IO;
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
    public int startingHealth;
    public int currentHealth;

    public Transform firePoint;
    //public GameObject bulletPrefab;

    HUD hud;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = startingHealth;
        healthSlider.maxValue = startingHealth;
        healthSlider.value = currentHealth;
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
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
            string text = File.ReadAllText(Application.dataPath + "/Scripts/Menu/High-Score.txt");
            int point = int.Parse(text);

            //Debug.Log("File"+point+"   current: "+hud.GetPoints());
            if (point < hud.GetPoints())
            {
                
                StreamWriter output = null;
                try
                {
                    output = File.CreateText(Application.dataPath + "/Scripts/Menu/High-Score.txt");
                    output.WriteLine(hud.GetPoints());


                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
                finally
                {
                    if (output != null)
                    {
                        output.Close();
                    }
                }

            }

            MenuManager.GoToMenu(MenuName.Main);
        }
    }


    public void IncreaseHealth(int level)
    {

        startingHealth = currentHealth + (level * 10);
        currentHealth = startingHealth;
        UpdateHealthBar();
       
    }

    public void IncreaseSpeed(int level)
    {
        moveSpeed = moveSpeed + 1;
    }
    void UpdateHealthBar()
    {
        healthSlider.value = currentHealth;
      
    }


    public void Health(int amount)
    {
        
        int newHealth = currentHealth + amount;
        if (newHealth > startingHealth)
        {
            currentHealth = startingHealth;
        }
        else if (newHealth < 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth = newHealth;
        }
        UpdateHealthBar();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUpItems"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("frozen"))
        {
            Destroy(other.gameObject);
           
        }

    }

   


}
