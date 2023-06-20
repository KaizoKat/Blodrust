using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandling : MonoBehaviour
{
    private bool interractWithDoor;
    [SerializeField] private float maxInterractDistance;
    [SerializeField] private LayerMask layer;

    void Update()
    {
        interractWithDoor = Input.GetButtonDown("Interract");

        if (interractWithDoor)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            
            if (Physics.Raycast(ray,out hit,maxInterractDistance,layer))
            {
                Animator otherAnimator = hit.transform.gameObject.transform.parent.GetComponent<Animator>();
                if(otherAnimator.GetBool("State") == false)
                {
                    otherAnimator.SetBool("Open", true);
                }
                
                if(otherAnimator.GetBool("State") == true)
                {
                    otherAnimator.SetBool("Close", true);
                }
            }
        }
    }
}
