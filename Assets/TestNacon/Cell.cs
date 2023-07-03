using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [Header("tiles accepted")]
    [SerializeField]
    private List<Tile> up = new List<Tile>();
    [SerializeField]
    private List<Tile> down = new List<Tile>();
    [SerializeField]
    private List<Tile> left = new List<Tile>();
    [SerializeField]
    private List<Tile> right = new List<Tile>();

    [Header("tile Stats")]
    [SerializeField]
    private bool isFull;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
