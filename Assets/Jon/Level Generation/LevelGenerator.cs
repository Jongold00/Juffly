using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class LevelGenerator : MonoBehaviour
{
    [Range(0, 100)]
    public int initChance;

    [Range(1, 8)]
    public int birthLimit;      // if a cell has fewer than this many neighbors, it will not be born

    [Range(1, 8)]
    public int deathLimit;      // if a cell has fewer than this many neighbors, it will stay dead

    [Range(1,10)]
    public int cycles;

    private int count;
    private int[,] terrainMap;
    public Vector3Int tmapSize;

    public Tilemap topMap;
    public Tilemap bottomMap;

    public Tile topTile;
    public Tile bottomTile;

    int width;
    int height;

    public void DoSim(int numReps)
    {
        clearMap(false);
        width = tmapSize.x;
        height = tmapSize.y;

        if (terrainMap == null)
        {
            terrainMap = new int[width, height];
            initPos();
        }

        for (int i = 0; i < numReps; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x,y] == 1)
                {
                    topMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), topTile);
                    bottomMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), bottomTile);
                }
                if (terrainMap[x, y] == 0)
                {
                    bottomMap.SetTile(new Vector3Int(-x + width / 2, -y + height / 2, 0), bottomTile);
                }

            }
        }
    }

    public int [,] genTilePos(int[,] oldMap)
    {
        int[,] newMap = new int[width, height];
        int numNeighbors;
        BoundsInt bounds = new BoundsInt(-1, -1, 0, 3, 3, 1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                numNeighbors = 0;
                foreach (var curr in bounds.allPositionsWithin)
                {
                    if (curr.x == 0 && curr.y == 0) continue;
                    if (x + curr.x >= 0 && x + curr.x < width && y + curr.y > 0 && y + curr.y < height)
                    {
                        numNeighbors += oldMap[x + curr.x, y + curr.y];
                    }
                    else
                    {
                        numNeighbors++;
                    }
                }
                if (oldMap[x,y] == 1)
                {
                    if (numNeighbors < deathLimit) newMap[x, y] = 0;
                    else
                    {
                        newMap[x, y] = 1;
                    }
        
                }
                if (oldMap[x, y] == 0)
                {
                    if (numNeighbors < birthLimit) newMap[x, y] = 1;
                    else
                    {
                        newMap[x, y] = 0;
                    }
                }
            }
        }
        return newMap;
    }

    public void initPos()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                terrainMap[x, y] = Random.Range(1, 101) < initChance ? 1 : 0;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DoSim(cycles);
        }

        if (Input.GetMouseButtonDown(1))
        {
            clearMap(true);
        }
    }

    public void clearMap(bool complete)
    {
        topMap.ClearAllTiles();
        bottomMap.ClearAllTiles();

        if (complete)
        {
            terrainMap = null;
        }
    }
}
