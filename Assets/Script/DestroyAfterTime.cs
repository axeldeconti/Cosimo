using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float _time = 0;

    private float _timeToBoom = 0;

    private void Start()
    {
        _timeToBoom = Time.time + _time;
    }

    private void Update()
    {
        if (Time.time > _timeToBoom)
            Destroy(gameObject);
    }
}
