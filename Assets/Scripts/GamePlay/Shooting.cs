
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;


    public Joystick joystickFire;
    public int rotationOffset;


    float shootDelay = 0.5f;
    float shootTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        

    }
    void FixedUpdate()
    {
        // Rotation
        if (joystickFire.joystickVec.x != 0 || joystickFire.joystickVec.y != 0)
        {
            float angle = Mathf.Atan2(joystickFire.joystickVec.y, joystickFire.joystickVec.x) * Mathf.Rad2Deg - 90f;
            if (angle != 0)
            {
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = q;
            }
        }

        Shoot();
    }
    private void Shoot()
    {
        shootTimer += Time.fixedDeltaTime;
        if(shootTimer < shootDelay)
        {
            return;
        }
        shootTimer = 0;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        AudioManager.Play(AudioClipName.GunSound);

    }
}
