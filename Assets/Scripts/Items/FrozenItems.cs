using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrozenItems : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Call the StopMovement method on the enemy script
            FrozenEnemy enemyScript = FindObjectOfType<FrozenEnemy>();
            enemyScript.StopMovement(5f);
            // Destroy the item GameObject
            Destroy(gameObject);
        }
    }
}
