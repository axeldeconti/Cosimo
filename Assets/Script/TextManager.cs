using System;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private AudioSource _aSource = null;

    [SerializeField] private GameObject _textParent = null;
    [SerializeField] private TextMeshProUGUI _text = null;
    [SerializeField] private Sentence _intro;
    [SerializeField] private Sentence[] _sentences = null;

    private void Start()
    {
        _aSource = GetComponent<AudioSource>();

        _textParent.SetActive(false);
    }

    public void PlayIntro()
    {
        _text.text = _intro.text;
        _aSource.clip = _intro.audio;
        _aSource.Play();
    }

    public void PlaySentence(int level)
    {
        _textParent.SetActive(true);
        _text.text = _sentences[level].text;
        _aSource.clip = _sentences[level].audio;
        _aSource.Play();
    }

    public void Hide()
    {
        _textParent.SetActive(false);
    }
}

[Serializable]
public struct Sentence
{
    [TextArea(2, 4)]
    public string text;
    public AudioClip audio;
}