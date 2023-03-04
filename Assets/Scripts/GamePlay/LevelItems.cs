using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelItems : MonoBehaviour
{
    public float expValue;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        LevelUp playerExp = collision.gameObject.GetComponent<LevelUp>();
        if (playerExp != null)
        {
            playerExp.SetExperience(expValue);
            Destroy(gameObject);

        }

    }
}
