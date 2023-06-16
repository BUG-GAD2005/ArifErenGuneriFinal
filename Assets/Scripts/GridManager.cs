using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int gridWidth, gridHeight;
    [SerializeField] private Tile tilePrefab;

    private Dictionary<Vector2, Tile> tiles;


    void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector2(x,y), Quaternion.identity);
                spawnedTile.name = $"Tile {x},{y}";
                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    public Tile GetTileAtPos(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out var tile))
        {
            return tile;
        }
        
        return null;
    }
}
