using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlanform : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _animator.Play("Fan_Run");
        }
    }
}