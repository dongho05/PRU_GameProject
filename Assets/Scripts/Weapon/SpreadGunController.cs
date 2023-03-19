using UnityEngine;

public class SpreadGunController : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject ammoType;

    public Joystick joystickFire;
    public int rotationOffset;

    //public float shotSpeed;
    //public float shotCounter, fireRate;
    public float bulletForce = 10f;
    // Start is called before the first frame update

    float shootDelay = 0.5f;
    float shootTimer = 0f;
    void Start()
    {

    }

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
        for (int i = 0; i <= 2; i++)
        {
            shootTimer += Time.fixedDeltaTime;
            if (shootTimer < shootDelay)
            {
                return;
            }
            shootTimer = 0;
            //GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
            //Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            //rb.AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);
            //Destroy(shot.gameObject, 1f);
            GameObject bullet = Instantiate(ammoType, firePoints[i].position, firePoints[i].rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoints[i].up * bulletForce, ForceMode2D.Impulse);
            AudioManager.Play(AudioClipName.GunSound);
        }



    }
}
