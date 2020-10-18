using System;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameObject _textParent = null;
    [SerializeField] private TextMeshProUGUI _text = null;
    [SerializeField] private Sentence _intro;
    [SerializeField] private Sentence[] _sentences = null;

    private void Start()
    {
        _textParent.SetActive(false);
    }

    public void PlayIntro()
    {
        _text.text = _intro.text;
    }

    public void PlaySentence(int level)
    {
        _textParent.SetActive(true);
        _text.text = _sentences[level].text;
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
}