using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Grid : MonoBehaviour
{
    private bool[,] grid = new bool[20,20];
    void Start()
    {
        for(int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = false;
            }
        }
    }

    void Update()
    {

    }

    /// <summary> this returns the neighbouring cells of target cell </summary>
    public bool[] GetNeighbouringCells(int x, int y)
    {
        bool[] neighbouring = new bool[4];

        neighbouring[0] = grid[x, y - 1];
        neighbouring[1] = grid[x + 1, y - 1];
        neighbouring[2] = grid[x + 1, y];
        neighbouring[3] = grid[x + 1, y + 1];
        neighbouring[4] = grid[x, y + 1];
        neighbouring[5] = grid[x - 1, y + 1];
        neighbouring[6] = grid[x - 1, y];
        neighbouring[7] = grid[x - 1, y - 1];

        return neighbouring;
    }

    public List<Vector2> GetAllActiveCellPositions()
    {
        List<Vector2> activeCells = new List<Vector2>();
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if(grid[i,j] == true)
                {
                    activeCells.Add(new Vector2(i, j));
                }
            }
        }
        return activeCells;
    }

}
