using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelection : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tilemap obstacleTilemap;
    [SerializeField] private float offset = 0.5f;
    [SerializeField] private Vector2 gridSize = new Vector2(1f, 2f);

    private Vector2Int highlightedTilePosition = Vector2Int.zero;

    private void Update()
    {
        
    }

    private Vector2Int HighlightedTilePosition
    {
        get { return highlightedTilePosition; }
    }

    public bool IsHighlightedTileClicked(Vector2 clickedPosition)
    {
        Vector2Int gridPos = GridUtils.WorldToGrid(clickedPosition);
        Debug.Log(gridPos);
        return gridPos == highlightedTilePosition;
        
    }


}
