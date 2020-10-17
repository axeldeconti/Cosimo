using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmosphereSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips = null;

    private AudioSource _aSource = null;
    private bool _isPlaying = false;

    private void Start()
    {
        _aSource = GetComponent<AudioSource>();
        _isPlaying = false;

        StartPlaying();
    }

    private void Update()
    {
        if (!_isPlaying)
            return;

        if (!_aSource.isPlaying)
            PlayRandom();
    }

    public void StartPlaying()
    {
        _isPlaying = true;
        PlayRandom();
    }

    private void PlayRandom()
    {
        _aSource.clip = _clips[Random.Range(0, _clips.Length)];
        _aSource.Play();
    }
}
