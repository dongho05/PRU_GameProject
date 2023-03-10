using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyItems : MonoBehaviour
{
    Timer destroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        destroyTimer = gameObject.AddComponent<Timer>();
        destroyTimer.Duration = 20;
        destroyTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyTimer.Finished)
        {
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
            destroyTimer.Duration = 20;
            destroyTimer.Run();
        }
    }
}
