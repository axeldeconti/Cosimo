using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogAndBird : MonoBehaviour
{
    private Animator _anim = null;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Trigger()
    {
        _anim.SetTrigger("trigger");
    }
}
