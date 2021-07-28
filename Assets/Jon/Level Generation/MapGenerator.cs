using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.Collections.Generic;

public class MapGenerator : MonoBehaviour
{
	public int minWidth;
	public int maxWidth;
	public int minHeight;
	public int maxHeight;

	public string seed;
	public bool useRandomSeed;

	[Range(0, 100)]
	public int randomFillPercent;

	int[,] map;

	[Range(1, 8)]
	public int birthLimit;
	[Range(1, 8)]
	public int deathLimit;
	[Range(1, 8)]
	public int numReps;

	public Tilemap topMap;
	public Tilemap botMap;

	public Tile[] basicTileSet = new Tile[16];

	int width;
	int height;

	int tileSize = 1;

	MarchingSquares.SquareGrid squareGrid;

	void Start()
	{
		
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GenerateMap();
		}
		if (Input.GetMouseButtonDown(1))
        {
			ResetMap();
        }
	}

	void GenerateMap()
	{
		width = Random.Range(minWidth, maxWidth);
		height = Random.Range(minHeight, maxHeight);

		map = new int[width, height];
		RandomFillMap();

		for (int i = 0; i < numReps; i++)
		{
			SmoothMap();
		}



		MarchingSquares marchingSquares = GetComponent<MarchingSquares>();
		squareGrid = marchingSquares.GenerateGrid(map, tileSize);


		FillMapTiles();



	}


	void RandomFillMap()
	{
		if (useRandomSeed)
		{
			seed = Time.time.ToString();
		}

		System.Random pseudoRandom = new System.Random(seed.GetHashCode());

		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
				{
					map[x, y] = 1;
				}
				else
				{
					map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
				}
			}
		}
	}

	void SmoothMap()
	{
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				int neighbourWallTiles = GetSurroundingWallCount(x, y);

				if (neighbourWallTiles > 4)
					map[x, y] = 1;
				else if (neighbourWallTiles < 4)
					map[x, y] = 0;

			}
		}
	}

	int GetSurroundingWallCount(int gridX, int gridY)
	{
		int wallCount = 0;
		for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
		{
			for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
			{
				if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
				{
					if (neighbourX != gridX || neighbourY != gridY)
					{
						wallCount += map[neighbourX, neighbourY];
					}
				}
				else
				{
					wallCount++;
				}
			}
		}

		return wallCount;
	}

	void ResetMap()
    {
		map = new int[width, height];
		topMap.ClearAllTiles();
		botMap.ClearAllTiles();
	}
	void FillMapTiles()
	{

		for (int x = 0; x < squareGrid.squares.GetLength(0); x++)
		{
			for (int y = 0; y < squareGrid.squares.GetLength(1); y++)
			{
				GetTile(squareGrid.squares[x, y]);
			}
		}

	}

	public void GetTile(MarchingSquares.Square square)
    {
		Tile currentTile = basicTileSet[square.configuration];
		if (square.configuration == 0)
        {
            botMap.SetTile(new Vector3Int(square.centerTop.position.x, square.centerTop.position.y, 0), currentTile);
		}
		else
        {
			topMap.SetTile(new Vector3Int(square.centerTop.position.x, square.centerTop.position.y, 0), currentTile);
		}
	}



}