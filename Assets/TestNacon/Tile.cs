using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("tiles accepted")]
    [SerializeField]
    internal List<Tile> up = new List<Tile>();
    [SerializeField]
    internal List<Tile> down = new List<Tile>();
    [SerializeField]
    internal List<Tile> left = new List<Tile>();
    [SerializeField]
    internal List<Tile> right = new List<Tile>();

    [Header("tile Stats")]
    [SerializeField]
    private bool isFull;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
