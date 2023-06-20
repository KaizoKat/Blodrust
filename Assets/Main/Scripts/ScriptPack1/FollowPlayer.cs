using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Follow;
    
    void Update()
    {
        transform.position = new Vector3(Follow.transform.position.x, transform.position.y, Follow.transform.position.z);
    }
}
