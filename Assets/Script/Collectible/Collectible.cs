﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject _collectibleUI = null;
    [SerializeField] private Transform _collectibleParent = null;
    [SerializeField] private Sprite _sprite = null;

    [Space]
    public UnityEvent onCollect = null;

    public GameObject AudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
        }
    }

    public void Collect()
    {
        //Player is touched
        Debug.Log(gameObject.name + " collected");
        GameObject col = Instantiate(_collectibleUI, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, _collectibleParent);
        col.GetComponent<Image>().sprite = _sprite;
        onCollect.Invoke();
        Instantiate(AudioSource);
        Destroy(gameObject);
    }
}