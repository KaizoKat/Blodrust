using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaLoading : MonoBehaviour
{
    private GameObject objectActivatorObject;
    private ObjectActivator activatorScript;

    private void Start()
    {
        objectActivatorObject = GameObject.FindWithTag("Generator");
        activatorScript = objectActivatorObject.GetComponent<ObjectActivator>();

        StartCoroutine("AddToList");
    }

    IEnumerator AddToList()
    {
        yield return new WaitForSeconds(0.01f);
        activatorScript.addList.Add(new ActivatorObject {obj = this.gameObject});
    }
}