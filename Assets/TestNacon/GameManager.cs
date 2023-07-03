using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    [SerializeField]
    private List<Cell> cells = new List<Cell>();

    [SerializeField]
    private List<Tile> tiles = new List<Tile>();

    public void AddCellInList(Cell cell)
    {
        cells.Add(cell);
    }

    public void GenerateMap()
    {
        Debug.Log("number of cells: " + cells.Count);

        int rndCell = Random.Range(0, cells.Count);
        Debug.Log("take the cell number: " + rndCell);
        Debug.Log("cellPosition: " + cells[rndCell].transform.position);

        int rndTile = Random.Range(0, tiles.Count);
        Debug.Log("take the cell number: " + rndTile);

        GameObject tile = Instantiate(tiles[rndTile].gameObject, cells[rndCell].transform.position, Quaternion.identity);
        Debug.Log("tilePosition: " + tile.transform.position);
    }


}
