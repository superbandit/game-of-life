using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Grid : MonoBehaviour
{
    private bool[,] oldGrid = new bool[20, 20];
    private bool[,] newGrid = new bool[20, 20];

    private GridRenderer Renderer;

    void Start()
    {
        for(int i = 0; i < oldGrid.GetLength(0); i++)
        {
            for (int j = 0; j < oldGrid.GetLength(1); j++)
            {
                oldGrid[i, j] = false;
            }
        }
        Renderer = this.GetComponent<GridRenderer>();
        Renderer.CreateBoard(oldGrid.GetLength(0), oldGrid.GetLength(1));
    }

    void Update()
    {

    }

    public void setCell(int x, int y, bool state)
    {
        newGrid[x, y] = state;
    }

    public bool getCell(int x, int y)
    {
        return oldGrid[x, y];
    }

    public void updateGrid()
    {
        for (int x = 0; x < oldGrid.GetLength(0); x++)
        {
            for (int y = 0; y < oldGrid.GetLength(1); y++)
            {
                oldGrid[x, y] = newGrid[x, y];
            }
        }
                
        for (int x = 0; x < oldGrid.GetLength(0); x++)
        {
            for (int y = 0; y < oldGrid.GetLength(1); y++)
            {
                Renderer.UpdateCell(x, y, oldGrid[x, y]);
            }
        }
    }

    /// <summary> this returns the neighbouring cells of target cell </summary>
    public bool[] GetNeighbouringCells(int x, int y)
    {
        bool[] neighbouring = new bool[8];

        neighbouring[0] = oldGrid[x - 1, y - 1];
        neighbouring[1] = oldGrid[x, y - 1];
        neighbouring[2] = oldGrid[x + 1, y - 1];
        neighbouring[3] = oldGrid[x - 1, y];
        neighbouring[4] = oldGrid[x + 1, y];
        neighbouring[5] = oldGrid[x - 1, y + 1];
        neighbouring[6] = oldGrid[x, y + 1];
        neighbouring[7] = oldGrid[x + 1, y + 1];

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
