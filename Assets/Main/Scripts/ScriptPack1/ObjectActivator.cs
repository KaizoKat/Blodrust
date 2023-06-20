using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActivator: MonoBehaviour
{
    [SerializeField] private int firstDistFromPlayer;
    [SerializeField] private int secondDistFromPlayer;
    private GameObject player;

    [HideInInspector] private List<ActivatorObject> activatorObjects;
    [HideInInspector] public List<ActivatorObject> addList;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        activatorObjects = new List<ActivatorObject>();
        addList = new List<ActivatorObject>();

        AddList();
    }

    void AddList()
    {
        if (addList.Count > 0)
        {
            foreach (ActivatorObject theObject in addList)
            {
                if(theObject.obj != null)
                    activatorObjects.Add(theObject);
            }

            addList.Clear();
        }

        StartCoroutine("CheckActivation");
    }

    IEnumerator CheckActivation()
    {
        List<ActivatorObject> removeList = new List<ActivatorObject>();
        
        if (activatorObjects.Count > 0)
        {
            foreach (ActivatorObject theObject in activatorObjects)
            {
                if (theObject.obj.transform.tag == "Room")
                {
                    if (Vector3.Distance(player.transform.position, theObject.obj.transform.position) > firstDistFromPlayer)
                    {
                        if (theObject.obj == null)
                        {
                            removeList.Add(theObject);
                        }
                        else
                        {
                            theObject.obj.SetActive(false);
                        }
                    }
                    else
                    {
                        if (theObject.obj == null)
                        {
                            removeList.Add(theObject);
                        }
                        else
                        {
                            theObject.obj.SetActive(true);
                        }
                    }
                }

                if(theObject.obj.transform.tag == "Light")
                {
                    if (theObject.obj.activeSelf == true)
                    {
                        if (Vector3.Distance(player.transform.position, theObject.obj.transform.position) > secondDistFromPlayer)
                        {
                            if (theObject.obj == null)
                            {
                                removeList.Add(theObject);
                            }
                            else
                            {
                                theObject.obj.GetComponent<Light>().enabled = false;
                            }
                        }
                        else
                        {
                            if (theObject.obj == null)
                            {
                                removeList.Add(theObject);
                            }
                            else
                            {
                                theObject.obj.GetComponent<Light>().enabled = true;
                            }
                        }
                    }

                }
            }
        }
        yield return new WaitForSeconds(0.01f);

        if (removeList.Count > 0)
        {
            foreach (ActivatorObject theObject in removeList)
            {
                activatorObjects.Remove(theObject);
            }
        }
        yield return new WaitForSeconds(0.01f);

        AddList();
    }
}

public class ActivatorObject
{
    public GameObject obj;
}
