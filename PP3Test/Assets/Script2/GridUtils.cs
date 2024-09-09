using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUtils : MonoBehaviour
{
    public static Vector2Int WorldToGrid(Vector2 worldPos)
    {
        return new Vector2Int(Mathf.FloorToInt(worldPos.x), Mathf.FloorToInt(worldPos.y));
    }

    public static Vector2 GridToWorld(Vector2 gridPos)
    {
        return new Vector2(gridPos.x, gridPos.y); 
    }
}
