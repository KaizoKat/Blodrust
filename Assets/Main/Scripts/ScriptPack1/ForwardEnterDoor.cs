using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardEnterDoor : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        transform.parent.transform.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 1);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent.transform.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 0);
    }
}
