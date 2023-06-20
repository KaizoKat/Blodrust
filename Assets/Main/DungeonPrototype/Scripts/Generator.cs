using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    public LevelCreationData _levelCreationData;
    public GameObject[] _prefabs;

    private HashSet<Vector3Int> _dungeonTiles;

    private void Start()
    {
        GenerateAMap();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Transform child in transform)
            {
                Destroy(child.transform.gameObject);
            }

            GenerateAMap();
        }
    }

    private void GenerateAMap()
    {
        _dungeonTiles = DrunkManager.Createmap(_levelCreationData);
        if (_levelCreationData._tileSize > 1)
        {
            _dungeonTiles = ReturnListOfScaledTiles(_dungeonTiles);
        }

        GameObject prefab = _prefabs[Random.Range(0, _prefabs.Length)];
        DrawDungeonTiles(_dungeonTiles, prefab);
        ApplyScaleModifier();
    }

    private void DrawDungeonTiles(IEnumerable<Vector3Int> tiles, GameObject prefab)
    {
        foreach (Vector3Int tileLocation in tiles)
        {
            Instantiate(prefab, new Vector3Int(tileLocation.x, tileLocation.y, tileLocation.z), Quaternion.identity, transform);

        }
    }

    private void ApplyScaleModifier()
    {
        foreach (Transform child in transform)
        {
            child.transform.localScale = Vector3.one * _levelCreationData._tileScale;
        }
    }

    private void ApplyOffseteModifier()
    {
        foreach (Transform child in transform)
        {
            child.transform.localScale = Vector3.one * _levelCreationData._tileScale;
        }
    }

    private HashSet<Vector3Int> ReturnListOfScaledTiles(IEnumerable<Vector3Int> tiles)
    {
        HashSet<Vector3Int> scaledTiles = new HashSet<Vector3Int>();

        foreach (Vector3Int tileLocation in tiles)
        {
            Vector3Int startPos = tileLocation * _levelCreationData._tileSize;
            Vector3Int newPosition;

            for (int i = 0; i < _levelCreationData._tileSize; i++)
            {
                for (int j = 0; j < _levelCreationData._tileSize; j++)
                {
                    for (int k = 0; k < _levelCreationData._tileSize; k++)
                    {
                        newPosition = new Vector3Int(i, j, k) + new Vector3Int(startPos.x, startPos.y,startPos.z);
                        scaledTiles.Add(newPosition);
                    }
                }
            }
        }

        return scaledTiles;
    }
}
