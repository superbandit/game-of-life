using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellUpdater : MonoBehaviour
{
    private Grid grid;

    private float updateTimer = 1;
    private bool gameStarted = true;

	void Start ()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
	}
	
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            grid.setCell(10, 6, true);
            grid.setCell(10, 7, true);
            grid.setCell(10, 8, true);
            grid.setCell(10, 9, true);
            grid.setCell(10, 10, true);
            grid.setCell(10, 11, true);
            /*
            grid.setCell(4, 4, true);
            grid.setCell(4, 5, true);
            grid.setCell(5, 4, true);
            grid.setCell(5, 5, true);
            grid.setCell(6, 4, true);
            grid.setCell(6, 5, true);
            */
            /*for(int i = 1; i < 19; i++)
            {
                for (int j = 1; j < 19; j++)
                {
                    grid.setCell(i, j, true);
                }
            }*/
        }
	    if (gameStarted == true)
        {
            if (updateTimer > 0)
            {
                updateTimer -= Time.deltaTime;
            }
            else
            {
                updateTimer = 1;
                UpdateCells();
            }        
        }
	}

    private void UpdateCells()
    {
        List<Vector2> currentActiveCells = grid.GetAllActiveCellPositions();

        checkActiveCells(currentActiveCells);
        checkNewCells();

        grid.updateGrid();
    }

    private void checkActiveCells(List<Vector2> currentActiveCells)
    {
        for (int i = 0; i < currentActiveCells.Count; i++)
        {
            int j = getNeighbouringCellAmount(currentActiveCells[i]);

            if (j < 2 || j > 3)
            {
                grid.setCell((int)currentActiveCells[i].x, (int)currentActiveCells[i].y, false);
            }
            if (j == 2 || j == 3)
            {
                grid.setCell((int)currentActiveCells[i].x, (int)currentActiveCells[i].y, true);
            }
        }
    }

    private void checkNewCells()
    {
        for (int i = 1; i < 18; i++)
        {
            for (int j = 1; j < 18; j++)
            {
                if (getNeighbouringCellAmount(new Vector2(i, j)) == 3)
                {
                    grid.setCell(i, j, true);
                }
            }
        }
    }

    private int getNeighbouringCellAmount(Vector2 cellposition)
    {
        int cellAmount = 0;
        bool[] cells = grid.GetNeighbouringCells((int)cellposition.x, (int)cellposition.y);
        for(int i = 0; i< cells.Length; i++)
        {
            if (cells[i])
            {
                cellAmount += 1;
            }
        }
        return cellAmount;
    }
}
