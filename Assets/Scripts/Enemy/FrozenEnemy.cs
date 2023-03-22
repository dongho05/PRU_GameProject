using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class FrozenEnemy : MonoBehaviour
{
    private bool isMoving = true;
    Vector3 endpoint;

    public void StopMovement(float duration)
    {
        if (isMoving)
        {
            isMoving = false;
            StartCoroutine(ResumeMovementAfterDelay(duration));
        }
    }

    IEnumerator ResumeMovementAfterDelay(float duration)
    {
        yield return new WaitForSeconds(duration);
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
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
            transform.position = Vector3.MoveTowards(transform.position, endpoint, Time.deltaTime);

            if (Vector3.Distance(transform.position, endpoint) < 0.001f)
            {
                endpoint = new Vector3(Random.Range(screenLeft, screenRight), Random.Range(screenBottom, screenTop), -Camera.main.transform.position.z);
            }
        }
    }
}
