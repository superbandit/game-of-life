using UnityEngine;
using System.Collections;

public class GridRenderer : MonoBehaviour
{
    [SerializeField]
    private GameObject Cell;
    [SerializeField]
    private Sprite Cell_On;
    [SerializeField]
    private Sprite Cell_Off;

    private GameObject[,] Grid;

    public void CreateBoard(int sizeX, int sizeY)
    {
        Grid = new GameObject[sizeX, sizeY];
        for (int x = 0; x < sizeX;  x++)
        {
            for(int y = 0; y < sizeY; y++)
            {
                Grid[x, y] = (GameObject)Instantiate(Cell, new Vector3(x, y, 0), Quaternion.identity);
            }
        }
    }

    public void UpdateCell(int x, int y, bool state)
    {
        if(state == true)
        {
            Grid[x, y].GetComponent<SpriteRenderer>().sprite = Cell_On;
        }
        if (state == false)
        {
            Grid[x, y].GetComponent<SpriteRenderer>().sprite = Cell_Off;
        }
    }
}
