using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CellUpdater : MonoBehaviour
{
    private Grid grid;

    private float updateTimer = 1; //seconds
    private bool gameStarted = false;

	void Start ()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
	}
	
	void Update ()
    {
	    if (gameStarted == true)
        {
            if (updateTimer > 0)
            {
                updateTimer -= Time.deltaTime;
            }
            else
            {
                UpdateCells();
            }
            
        }
	}

    private void UpdateCells()
    {
        List<Vector2> currentActiveCells = grid.GetAllActiveCellPositions();
        for (int i = 0; i < currentActiveCells.Count; i++)
        {
            NeighbouringCellAmount(currentActiveCells[i]);
        }
    }

    private int NeighbouringCellAmount(Vector2 cellposition)
    {
        grid.GetNeighbouringCells((int)cellposition.x, (int)cellposition.y);//todo
    }
}
