using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private bool isFull;

    void Start()
    {
        gameManager.AddCellInList(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
