using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool isVisited = false;
        public bool[] status = new bool[4];
    }

    [SerializeField]
    private Vector2 size;
    [SerializeField]
    private int startPosition = 0;
    [SerializeField]
    private GameObject room;
     [SerializeField]
    private Vector2 roomOffset;
    [SerializeField]
    private GameObject fogPiece; 

    private List<Cell> board;

    // Start is called before the first frame update
    void Start()
    {
        MazeGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateDungeon()
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int z = 0; z < size.y; z++)
            {

                //Cell currentCell = board[Mathf.FloorToInt(x + z * size.x)];
                Room newRoom = Instantiate(room, new Vector3(x * roomOffset.x, 0, -z * roomOffset.y), Quaternion.identity, transform).GetComponent<Room>();
                newRoom.UpdateRoom(board[Mathf.FloorToInt(x+z*size.x)].status);
                newRoom.name = "room " + x + "-" + z;
                Debug.Log(newRoom.name);
                newRoom.isVisitedRoom = board[Mathf.FloorToInt(x + z * size.x)].isVisited;
            }
        }

        CreateFogOfWar();
    }

    private void MazeGenerator()
    {
        board = new List<Cell>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        int currentCell = startPosition;

        Stack<int> path = new Stack<int>();

        int debugValue = 0;
        while (debugValue < 1000)
        {
            debugValue++;
           
            if (currentCell == board.Count - 1)
            {
                break;
            }
            else
            {
                board[currentCell].isVisited = true;
            }

            //Check the cell's neighbors
            List<int> neighbors = CheckNeighbors(currentCell);

            if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                if (newCell > currentCell)
                {
                    //down or right
                    if (newCell - 1 == currentCell)
                    {
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
                    }
                    else
                    {
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;
                    }
                }
                else
                {
                    //up or left
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;
                    }
                }

            }

        }
        GenerateDungeon();
    }

    private List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //check up neighbor
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].isVisited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
        }

        //check down neighbor
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].isVisited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }

        //check right neighbor
        if ((cell + 1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].isVisited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        //check left neighbor
        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].isVisited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbors;
    }


    private void CreateFogOfWar()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject fog = Instantiate(fogPiece, new Vector3(i * roomOffset.x, 2, -j * roomOffset.y), Quaternion.Euler(90, 0, 0));
            }
        }
    }
}
