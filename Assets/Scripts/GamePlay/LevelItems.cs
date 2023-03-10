using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItems : MonoBehaviour
{
    public float expValue;

    private void OnTriggerEnter2D(Collider2D other)
    {

        LevelUp playerExp = other.gameObject.GetComponent<LevelUp>();
        if (playerExp != null)
        {
            playerExp.SetExperience(expValue);
            Destroy(gameObject);

        }

    }
}
