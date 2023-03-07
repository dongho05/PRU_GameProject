using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;


    public Joystick joystickFire;
    public int rotationOffset;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Shoot();
            AudioManager.Play(AudioClipName.GunSound);

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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
