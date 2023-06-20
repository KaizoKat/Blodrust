using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject objectSpawn;

    private void Start()
    {
        objectSpawn = GameObject.FindGameObjectWithTag("Player").gameObject;
        objectSpawn.transform.position = transform.position + offset;
    }
}
