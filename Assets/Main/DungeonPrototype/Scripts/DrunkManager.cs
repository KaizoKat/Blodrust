using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction
{
    zPlus = 0,
    xPlus = 1,
    zMinus = 2,
    xMinus = 3,
    yPlus = 4,
    yMinus = 5
};


public class DrunkManager : MonoBehaviour
{
    private static readonly Dictionary<Direction, Vector3Int> _dirMovmentMap = new Dictionary<Direction, Vector3Int>
    {
        {Direction.zPlus, Vector3Int.forward},
        {Direction.zMinus, Vector3Int.back},
        {Direction.xPlus, Vector3Int.right},
        {Direction.xMinus, Vector3Int.left},
        {Direction.yPlus, Vector3Int.up},
        {Direction.yMinus, Vector3Int.down}
    };

    public static HashSet<Vector3Int> Createmap(LevelCreationData levelData)
    {
        List<DrunkWalker> drunkWalkers = new List<DrunkWalker>();
        HashSet<Vector3Int> positionsVisited = new HashSet<Vector3Int>();

        for (int i = 0; i < levelData._numberOfWalkers; i++)
        {
            drunkWalkers.Add(new DrunkWalker(Vector3Int.zero));
        }

        for (int i = 0; i < levelData._numberOfIterations; i++)
        {
            foreach (DrunkWalker drunkWalker in drunkWalkers)
            {
                Vector3Int newPosition = drunkWalker.Move(_dirMovmentMap) * levelData._tileSeparation;
                positionsVisited.Add(newPosition);
            }
        }

        return positionsVisited;
    }
}
