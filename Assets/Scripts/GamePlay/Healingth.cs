using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healingth : MonoBehaviour
{
    public float healAmount;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        CharacterMovement playerHealth = collision.gameObject.GetComponent<CharacterMovement>();
        if (playerHealth != null)
        {
            playerHealth.Health(healAmount);
            Destroy(gameObject);

        }

    }
}
