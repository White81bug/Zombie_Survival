
using UnityEngine;

public class ScreenUtils : MonoBehaviour
{
    public static Vector2 GetMousePosition2d()
    {
        return (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
