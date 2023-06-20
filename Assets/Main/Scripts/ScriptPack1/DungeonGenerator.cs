using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DungeonGenerator : MonoBehaviour
{
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4];
    }
    [System.Serializable]
    public class Rule
    {
        public GameObject room;
        public Vector2Int minPosition;
        public Vector2Int maxPosition;

        public bool obligatory;

        public int ProbabilityOfSpawning(int x, int y)
        {
            if (x >= minPosition.x && x <= maxPosition.x && y >= minPosition.y && y <= maxPosition.y)
            {
                return obligatory ? 2 : 1;
            }

            return 0;
        }
    }

    [SerializeField] private Vector2 size;
    [SerializeField] private int startPos = 0;
    [SerializeField] private Rule[] rooms;
    [SerializeField] private Vector2 offset;

    private List<Cell> board = new List<Cell>();

    private void Start()
    {
        MazeGenerator();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Random.InitState(Random.Range(0, 100000));
            
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            
            board.Clear();
            MazeGenerator();
        }
    }

    void GenerateDungeon()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i + j * size.x)];
                if (currentCell.visited)
                {
                    int randomRoom = -1;
                    List<int> avilableRooms = new List<int>();

                    for (int k = 0; k < rooms.Length; k++)
                    {
                        int p = rooms[k].ProbabilityOfSpawning(i, j);

                        if (p == 2)
                        {
                            randomRoom = k;
                            break;
                        }
                        else if (p == 1)
                        {
                            avilableRooms.Add(k);
                        }
                    }

                    if (randomRoom == -1)
                    {
                        if (avilableRooms.Count > 0)
                        {
                            randomRoom = avilableRooms[Random.Range(0, avilableRooms.Count)];
                        }
                        else
                        {
                            randomRoom = 0;
                        }
                    }
                    
                    var newRoom = Instantiate(rooms[randomRoom].room, new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehaviour>();
                    newRoom.UpdateRoom(board[Mathf.FloorToInt(i+j*size.x)].status);

                    newRoom.name += "Room " + i + "-" + j;
                }
            }
        }
    }

    void MazeGenerator()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        int currentCell = startPos;
        Stack<int> path = new Stack<int>();

        int k = 0;
        while (k < 1000)
        {
            k++;
            board[currentCell].visited = true;
            
            if(currentCell == board.Count -1)
                break;

            List<int> neghbors = CheckNeibours(currentCell);

            if (neghbors.Count == 0)
            {
                if (path.Count == 0)
                    break;
                else
                    currentCell = path.Pop();
            }
            else
            {
                path.Push(currentCell);

                int newCell = neghbors[Random.Range(0, neghbors.Count)];

                if (newCell > currentCell)
                {
                    if (newCell - 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
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
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
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

    List<int> CheckNeibours(int cell)
    {
        List<int> neibors = new List<int>();
        
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell-size.x)].visited)
            neibors.Add(Mathf.FloorToInt(cell-size.x));
        
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell+size.x)].visited)
            neibors.Add(Mathf.FloorToInt(cell+size.x));
        
        if ((cell+1) % size.x != 0 && !board[Mathf.FloorToInt(cell+1)].visited)
            neibors.Add(Mathf.FloorToInt(cell+1));
        
        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell-1)].visited)
            neibors.Add(Mathf.FloorToInt(cell-1));

        return neibors;
    }
}
