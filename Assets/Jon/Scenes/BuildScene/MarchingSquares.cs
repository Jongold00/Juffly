using UnityEngine;
using System.Collections;

public class MarchingSquares : MonoBehaviour
{

	public SquareGrid squareGrid;

	public SquareGrid GenerateGrid(int[,] map, int squareSize)
	{
		return squareGrid = new SquareGrid(map, squareSize);
	}



	public class SquareGrid
	{
		public Square[,] squares;

		public SquareGrid(int[,] map, int squareSize)
		{
			int nodeCountX = map.GetLength(0);
			int nodeCountY = map.GetLength(1);
			int mapWidth = nodeCountX * squareSize;
			int mapHeight = nodeCountY * squareSize;

			ControlNode[,] controlNodes = new ControlNode[nodeCountX, nodeCountY];

			for (int x = 0; x < nodeCountX; x++)
			{
				for (int y = 0; y < nodeCountY; y++)
				{
					Vector3Int pos = new Vector3Int(-mapWidth / 2 + x * squareSize + squareSize / 2, -mapHeight / 2 + y * squareSize + squareSize / 2, 0);
					controlNodes[x, y] = new ControlNode(pos, map[x, y] == 1, squareSize);
				}
			}

			squares = new Square[nodeCountX - 1, nodeCountY - 1];
			for (int x = 0; x < nodeCountX - 1; x++)
			{
				for (int y = 0; y < nodeCountY - 1; y++)
				{
					squares[x, y] = new Square(controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y]);
				}
			}

		}
	}

	public class Square
	{

		public ControlNode topLeft, topRight, bottomRight, bottomLeft;
		public Node centerTop, centerRight, centerBottom, centerLeft;
		public int configuration;

		public Square(ControlNode _topLeft, ControlNode _topRight, ControlNode _bottomRight, ControlNode _bottomLeft)
		{
			topLeft = _topLeft;
			topRight = _topRight;
			bottomRight = _bottomRight;
			bottomLeft = _bottomLeft;

			centerTop = topLeft.right;
			centerRight = bottomRight.above;
			centerBottom = bottomLeft.right;
			centerLeft = bottomLeft.above;

			if (topLeft.active)
            {
				configuration += 8;
            }
			if (topRight.active)
			{
				configuration += 4;
			}
			if (bottomRight.active)
			{
				configuration += 2;
			}
			if (bottomLeft.active)
			{
				configuration += 1;

			}
		}
	}

	public class Node
	{
		public Vector3Int position;
		public int vertexIndex = -1;

		public Node(Vector3Int _pos)
		{
			position = _pos;
		}
	}

	public class ControlNode : Node
	{

		public bool active;
		public Node above, right;

		public ControlNode(Vector3Int _pos, bool _active, int squareSize) : base(_pos)
		{
			active = _active;
			above = new Node(position + Vector3Int.forward * squareSize / 2);
			right = new Node(position + Vector3Int.right * squareSize / 2);
		}

	}
}