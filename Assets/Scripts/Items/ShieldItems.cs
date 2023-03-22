using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItems : MonoBehaviour
{
    public int shieldHealth = 100;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is hit by an enemy bullet
        if (collision.gameObject.tag == "bulletEnemy")
        {
            // Subtract damage from the shield health
            shieldHealth -= 20;

            // Play a visual effect or animation to indicate damage taken
            // ...

            // If the shield health reaches zero, disable the shield
            if (shieldHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
