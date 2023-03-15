using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBoss : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCircle;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 50;
        timer.Run();
    }

    List<GameObject> circles = new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {

            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            // save screen edges in world coordinates
            float screenZ = -Camera.main.transform.position.z;
            Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
            Vector3 upperRightCornerScreen = new Vector3(
                screenWidth, screenHeight, screenZ);
            Vector3 lowerLeftCornerWorld =
                Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
            Vector3 upperRightCornerWorld =
                Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
            float screenLeft = lowerLeftCornerWorld.x;
            float screenRight = upperRightCornerWorld.x;
            float screenTop = upperRightCornerWorld.y;
            float screenBottom = lowerLeftCornerWorld.y;


            circles.Add(Instantiate<GameObject>(prefabCircle, new Vector3(Random.Range(screenLeft, screenRight), Random.Range(screenBottom, screenTop), screenZ), Quaternion.identity));
            timer.Duration = 50;
            timer.Run();
        }
    }
}
