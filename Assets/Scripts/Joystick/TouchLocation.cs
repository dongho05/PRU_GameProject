
using UnityEngine;

public class TouchLocation
{
    public int touchId;
    public GameObject circle;

    public TouchLocation(int touchId, GameObject circle)
    {
        this.touchId = touchId;
        this.circle = circle;
    }
}
