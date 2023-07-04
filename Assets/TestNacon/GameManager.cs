using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    [Header("Game creator")]
    [SerializeField]
    private GameObject[] zones;
    [SerializeField]
    private List<GameObject> zonesUsed = new List<GameObject>();
    [SerializeField]
    private GameObject monster;
    [SerializeField]
    private GameObject teleport;
    [SerializeField]
    private GameObject mold;
    [SerializeField]
    private GameObject fogPiece;

    [Header("Warning Panel")]
    [SerializeField]
    internal GameObject teleportPanel;
    [SerializeField]
    internal GameObject monsterPanel;
    [SerializeField]
    internal GameObject moldPanel;

    private void Start()
    {
        IstantiateTriggerInRandomPosition(monster, "monster", 1);
        IstantiateTriggerInRandomPosition(teleport, "teleport 1", 0.2f);
        IstantiateTriggerInRandomPosition(mold, "mold 1", 0.2f);
        IstantiateTriggerInRandomPosition(teleport, "teleport 2", 0.2f);
        IstantiateTriggerInRandomPosition(mold, "mold 2", 0.2f);

        //CreateFogOfWar();
    }
    private void Update()
    {
        
    }

    private void IstantiateTriggerInRandomPosition(GameObject obj, string name, float offsetY)
    {
        bool intantiate = false;

        int rndZone = 0;
        int rndTile = 0;
        do
        {
            rndZone = (int)Random.Range(0, zones.Length);
            rndTile = (int)Random.Range(0, zones[rndZone].transform.childCount);

            if(!zones[rndZone].transform.GetChild(rndTile).gameObject.GetComponent<Tile>().isFull && !zonesUsed.Contains(zones[rndZone]))
            {
                intantiate = true;
            }
        }
        while (!intantiate);

        GameObject GO = Instantiate(obj, zones[rndZone].transform.GetChild(rndTile).position + new Vector3(0, offsetY, 0), Quaternion.identity);
        GO.name = name;
        zones[rndZone].transform.GetChild(rndTile).gameObject.GetComponent<Tile>().isFull = true;
        zonesUsed.Add(zones[rndZone]);
    }

    public void TeleportPlayer(NaconPlayer player)
    {
        player.canMove = false;
        bool findPosition = false;
        int rndZone = (int)Random.Range(0, zones.Length);
        int rndTile = 0;
        do
        {
            rndTile = (int)Random.Range(0, zones[rndZone].transform.childCount);
            if (!zones[rndZone].transform.GetChild(rndTile).gameObject.GetComponent<Tile>().isFull)
            {
                findPosition = true;
            }
        }
        while (!findPosition);
        player.gameObject.transform.position = zones[rndZone].transform.GetChild(rndTile).position + new Vector3(0,1,0);
        player.canMove = true;
    }

    private void CreateFogOfWar()
    {
        foreach(GameObject go in zones)
        {
            foreach(Transform child in go.transform)
            {
                GameObject fog = Instantiate(fogPiece, child.position + new Vector3(0, 2, 0), Quaternion.Euler(90,0,0));
            }
        }
    }
}
