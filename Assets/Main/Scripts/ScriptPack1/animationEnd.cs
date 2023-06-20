using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationEnd : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    void FinnishClose()
    {
        _animator.SetBool("Close",false);
        _animator.SetBool("State",false);
    }

    void FinnishOpen()
    {
        _animator.SetBool("Open",false);
        _animator.SetBool("State",true);
    }
}
