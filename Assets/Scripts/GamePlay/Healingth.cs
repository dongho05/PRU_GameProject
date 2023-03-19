
using UnityEngine;

public class Healingth : MonoBehaviour
{
    public int healAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {

        CharacterMovement playerHealth = other.gameObject.GetComponent<CharacterMovement>();
        if (playerHealth != null)
        {
            playerHealth.Health(healAmount);
            Destroy(gameObject);

        }

    }
}
