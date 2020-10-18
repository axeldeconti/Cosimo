using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextManager : MonoBehaviour
{
    [SerializeField] private GameObject _textParent = null;
    [SerializeField] private TextMeshProUGUI _textGauche = null;
    [SerializeField] private TextMeshProUGUI _textDroite = null;
    [SerializeField] private Sentence _intro;
    [SerializeField] private Sentence[] _sentences = null;
    [SerializeField] private AudioClip[] _clips = null;

    [Space]
    public UnityEvent onEndSentence = null;

    private bool _isOpen = false;
    private bool _hasCollectible = false;
    private AudioSource _aSource = null;

    private void Start()
    {
        _aSource = GetComponent<AudioSource>();
        _textParent.SetActive(false);
        _isOpen = false;
        LevelManager.instance.OnLevelChange += PlaySentence;
    }

    private void Update()
    {
        if (!_isOpen)
            return;

        if (Input.GetButtonDown("Interact"))
        {
            Hide();
            onEndSentence.Invoke();
        }
    }

    public void PlayIntro()
    {
        _textGauche.text = _intro.textGauche;
        _textDroite.text = _intro.textDroite;
        _isOpen = true;
    }

    public void PlaySentence(int level)
    {
        if (_hasCollectible)
        {
            _textParent.SetActive(true);
            _textGauche.text = _sentences[level - 1].textGauche;
            _textDroite.text = _sentences[level - 1].textDroite;
            _isOpen = true;

            _aSource.clip = _clips[UnityEngine.Random.Range(0, _clips.Length)];
            _aSource.Play();
        }
        else
        {
            StartCoroutine(Delay());
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        onEndSentence.Invoke();
    }

    public void Hide()
    {
        _textParent.SetActive(false);
        _isOpen = false;
        _hasCollectible = false;
    }

    public void SetCollectible()
    {
        _hasCollectible = true;
    }
}

[Serializable]
public struct Sentence
{
    [TextArea(2, 4)]
    public string textGauche;
    [TextArea(2, 4)]
    public string textDroite;
}