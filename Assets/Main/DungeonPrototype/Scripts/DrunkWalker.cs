using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DrunkWalker
{
    public Vector3Int Position { get; set; }

    public DrunkWalker(Vector3Int startPos)
    {
        Position = startPos;
    }

    public Vector3Int Move(Dictionary<Direction, Vector3Int> _dirMovmentMap)
    {
        Direction toMove = (Direction)Random.Range(0, _dirMovmentMap.Count);
        Position += _dirMovmentMap[toMove];
        return Position;
    }
}
