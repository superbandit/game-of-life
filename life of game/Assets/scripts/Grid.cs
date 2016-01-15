using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Grid : MonoBehaviour
{
    private bool[,] oldGrid = new bool[20, 20];
    private bool[,] newGrid = new bool[20, 20];

    void Start()
    {
        for(int i = 0; i < oldGrid.GetLength(0); i++)
        {
            for (int j = 0; j < oldGrid.GetLength(1); j++)
            {
                oldGrid[i, j] = false;
            }
        }
    }

    void Update()
    {

    }

    public void setCell(int x, int y, bool state)
    {
        newGrid[x, y] = state;
    }

    public void updateGrid()
    {
        oldGrid = newGrid;
    }

    /// <summary> this returns the neighbouring cells of target cell </summary>
    public bool[] GetNeighbouringCells(int x, int y)
    {
        bool[] neighbouring = new bool[8];

        neighbouring[0] = oldGrid[x, y - 1];
        neighbouring[1] = oldGrid[x + 1, y - 1];
        neighbouring[2] = oldGrid[x + 1, y];
        neighbouring[3] = oldGrid[x + 1, y + 1];
        neighbouring[4] = oldGrid[x, y + 1];
        neighbouring[5] = oldGrid[x - 1, y + 1];
        neighbouring[6] = oldGrid[x - 1, y];
        neighbouring[7] = oldGrid[x - 1, y - 1];

        return neighbouring;
    }

    public List<Vector2> GetAllActiveCellPositions()
    {
        List<Vector2> activeCells = new List<Vector2>();
        for (int i = 0; i < oldGrid.GetLength(0); i++)
        {
            for (int j = 0; j < oldGrid.GetLength(1); j++)
            {
                if(oldGrid[i,j] == true)
                {
                    activeCells.Add(new Vector2(i, j));
                }
            }
        }
        return activeCells;
    }

}
