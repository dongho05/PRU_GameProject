using UnityEngine;

public class SpreadGunController : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject ammoType;

    public Joystick joystickFire;
    public int rotationOffset;

    //public float shotSpeed;
    //public float shotCounter, fireRate;
    public float bulletForce = 20f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Shoot();
        }
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
    }
    private void Shoot()
    {
        foreach (var firePoint in firePoints)
        {
            //GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
            //Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            //rb.AddForce(firePoint.up * shotSpeed, ForceMode2D.Impulse);
            //Destroy(shot.gameObject, 1f);
            GameObject bullet = Instantiate(ammoType, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        }

    }
}
