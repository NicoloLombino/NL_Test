using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningAreaTrigger : MonoBehaviour
{
    // just for look it in ispector
    private enum Area
    {
        mold,
        monster,
        teleport
    }

    [SerializeField]
    private Area area;

    [SerializeField]
    private GameObject warningPanel;

    private GameManager gameManager;


    // Start is called before the first frame update
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        switch (area)
        {
            case Area.mold:
                warningPanel = gameManager.moldPanel;
                break;
            case Area.teleport:
                warningPanel = gameManager.teleportPanel;
                break;
            case Area.monster:
                warningPanel = gameManager.monsterPanel;
                break;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    { 
        if(other.CompareTag("Player"))
        {
            warningPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            warningPanel.SetActive(false);
        }
    }


}
