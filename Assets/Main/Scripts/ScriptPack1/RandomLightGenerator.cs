using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomLightGenerator : MonoBehaviour
{
    [SerializeField] private GameObject Lit;
    [SerializeField] private bool RandomTOrSetF, LitTOrUnlitF;  // Is the light random (true) or preset (false)
                                                                // Is the light lit (true) or unlit (false)


    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        byte lightInstancePicker = (byte)Random.Range(0, 3);

        if (RandomTOrSetF) // is true
        {
            switch (lightInstancePicker)
            {
                case 0:// invizible
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    Lit.SetActive(false);
                    break;

                case 1: // lit
                    Lit.SetActive(true);
                    break;

                case 2: // unlit
                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Lit.SetActive(false);
                    break;
            }
        }
        else // is false
        {
            if (LitTOrUnlitF) // is true
            {
                Lit.SetActive(true);
            }
            else // is false
            {
                gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
