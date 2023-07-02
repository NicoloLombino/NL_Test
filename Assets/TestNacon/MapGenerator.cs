using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private int cellsNumber;

    [SerializeField]
    private List<CellTile> tiles = new List<CellTile>();
}
