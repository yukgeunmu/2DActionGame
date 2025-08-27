using UnityEngine;

public class MapManager
{
    public Vector2[] points = new Vector2[12];
    public void Init()
    {
        points[0] = new Vector2(-7, -1);
        points[1] = new Vector2(7, 3);
        points[2] = new Vector2(-8, -3);
        points[3] = new Vector2(-7, -3);
        points[4] = new Vector2(-6, -3);
        points[5] = new Vector2(-5, -3);
        points[6] = new Vector2(-4, -3);
        points[7] = new Vector2(8, -3);
        points[8] = new Vector2(7, -3);
        points[9] = new Vector2(6, -3);
        points[10] = new Vector2(5, -3);
        points[11] = new Vector2(4, -3);
    }

}
