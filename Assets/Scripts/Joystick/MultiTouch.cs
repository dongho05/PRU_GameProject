
using System.Collections.Generic;
using UnityEngine;

public class MultiTouch : MonoBehaviour
{
    public GameObject circle;
    public List<TouchLocation> touches = new List<TouchLocation>();


    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("began");
            }
            else if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("moved");
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("ended");
            }
            ++i;
        }
    }
}
