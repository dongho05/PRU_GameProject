using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateRandomEnemy : MonoBehaviour
{

    [SerializeField]
    GameObject prefabCircle;
    [SerializeField]
    GameObject prefabEnemyAlpha;
    [SerializeField]
    GameObject prefabEnemyDelta;
    //[SerializeField]
    //GameObject prefabEnemyBoss;
    Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 5;
        timer.Run();
        circles.Add(prefabEnemyAlpha);
        circles.Add(prefabCircle);
        circles.Add(prefabEnemyDelta);
    }

    List<GameObject> circles = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {

            //float screenWidth = Screen.width;
            //float screenHeight = Screen.height;
            // save screen edges in world coordinates
            float screenZ = -Camera.main.transform.position.z;
            //Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
            //Vector3 upperRightCornerScreen = new Vector3(
            //    screenWidth, screenHeight, screenZ);
            //Vector3 lowerLeftCornerWorld =
            //    Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
            //Vector3 upperRightCornerWorld =
            //    Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
            //float screenLeft = lowerLeftCornerWorld.x;
            //float screenRight = upperRightCornerWorld.x;
            //float screenTop = upperRightCornerWorld.y;
            //float screenBottom = lowerLeftCornerWorld.y;
            int prefabIndex = Random.Range(0, circles.Count);
            //circles.Add(Instantiate<GameObject>(circles.ElementAt<GameObject>(prefabIndex), new Vector3(Random.Range(screenLeft, screenRight), Random.Range(screenBottom, screenTop), screenZ), Quaternion.identity));
            Instantiate<GameObject>(circles.ElementAt<GameObject>(prefabIndex), new Vector3(Random.Range(-20, 20), Random.Range(-10.5f, 10.5f), screenZ), Quaternion.identity);
            timer.Duration = 5;
            timer.Run();
        }

    }
}
