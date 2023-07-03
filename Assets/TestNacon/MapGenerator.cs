using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]
    private int mapHeight;

    [SerializeField]
    private int mapWidth;

    [SerializeField]
    private List<Tile> tiles = new List<Tile>();

    [SerializeField]
    private Tile firstTile;
    [SerializeField]
    private int tileOffset;

    private void Start()
    {
        //GenerateRandomMap();
        StartCoroutine(AAA());
    }

    public void GenerateRandomMap()
    {
        Tile previousTile = null;
        for(int x = 0; x < mapHeight; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                if(x == 0)
                {
                    if (previousTile == null)
                    {
                        GameObject tile = Instantiate(firstTile.gameObject);
                        tile.transform.position = new Vector3(x * tileOffset, 0, z * tileOffset);
                        previousTile = tile.GetComponent<Tile>();
                        tile.name = "tile" + x + z;
                    }
                    else
                    {
                        bool tileAccepted = false;
                        int rndValue = 0;
                        while (!tileAccepted)
                        {
                            int rndTile = Random.Range(0, tiles.Count);
                            Debug.Log("rndTile = " + rndTile);
                            if (previousTile.up.Contains(tiles[rndTile]) /*|| previousTile.down.Contains(tiles[rndTile])
                        || previousTile.left.Contains(tiles[rndTile]) || previousTile.right.Contains(tiles[rndTile])*/)
                            {
                                tileAccepted = true;
                                rndValue = rndTile;
                            }
                        }
                        GameObject tile = Instantiate(tiles[rndValue].gameObject);
                        tile.transform.position = new Vector3(x * tileOffset, 0, z * tileOffset);
                        previousTile = tile.GetComponent<Tile>();
                        tile.name = "tile" + x + z;
                    }
                }
                else
                {                  
                    if (z == 0)
                    {
                        Tile nearTileLeft = GameObject.Find("tile" + (x - 1) + z).GetComponent<Tile>();
                        bool tileAcceptedLeft = false;
                        int rndValue = 0;
                        while (!tileAcceptedLeft)
                        {
                            int rndTile = Random.Range(0, tiles.Count);
                            Debug.Log("rndTile = " + rndTile);
                            if (nearTileLeft.right.Contains(tiles[rndTile]))
                            {
                                tileAcceptedLeft = true;
                                rndValue = rndTile;
                            }
                        }
                        GameObject tile = Instantiate(tiles[rndValue].gameObject);
                        tile.transform.position = new Vector3(x * tileOffset, 0, z * tileOffset);
                        tile.name = "tile" + x + z;
                    }
                    else
                    {
                        Tile nearTileLeft = GameObject.Find("tile" + (x - 1) + z).GetComponent<Tile>();
                        Tile nearTileDown = GameObject.Find("tile" + x  + (z - 1)).GetComponent<Tile>();

                        bool tileAcceptedLeft = false;
                        bool tileAcceptedDown = false;
                        int rndValue = 0;
                        while (!tileAcceptedLeft || !tileAcceptedDown)
                        {
                            int rndTile = Random.Range(0, tiles.Count);
                            Debug.Log("rndTile = " + rndTile);
                            if (nearTileLeft.right.Contains(tiles[rndTile]) && nearTileDown.down.Contains(tiles[rndTile]))
                            {
                                tileAcceptedLeft = true;
                                tileAcceptedDown = true;
                                rndValue = rndTile;
                            }
                        }
                        GameObject tile = Instantiate(tiles[rndValue].gameObject);
                        tile.transform.position = new Vector3(x * tileOffset, 0, z * tileOffset);
                        tile.name = "tile" + x + z;
                    }

                }
            }
        }
    }

    private IEnumerator AAA()
    {
        yield return new WaitForSeconds(0.2f);
        GenerateRandomMap();
    }
}
