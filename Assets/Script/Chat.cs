using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{
    private Animator _anim = null;
    private bool _trigger1 = false;
    private bool _trigger2 = false;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _trigger1 = false;
        _trigger2 = false;
    }

    public void Trigger1()
    {
        if (!_trigger1)
        {
            _anim.SetTrigger("trigger1");
            _trigger1 = true;
        }
    }

    public void Trigger2()
    {
        if (!_trigger2)
        {
            _anim.SetTrigger("trigger2");
            _trigger2 = true;
        }
    }
}