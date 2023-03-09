using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject weaponToGive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            collision.gameObject.GetComponent<WeaponSwap>().UpdateWeapon(weaponToGive);
            Destroy(GameObject.FindGameObjectWithTag("Gun"));
            Destroy(gameObject);
        }
    }
}
