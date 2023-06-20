using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardEnterDoor : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        transform.parent.transform.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 2);
    }

    private void OnTriggerExit(Collider other)
    {
        transform.parent.transform.gameObject.GetComponentInChildren<Animator>().SetInteger("Position", 0);
    }
}
