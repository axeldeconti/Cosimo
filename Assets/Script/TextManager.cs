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
    private bool _canHide = true;
    private AudioSource _aSource = null;

    #region Instance
    public static TextManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    private void Start()
    {
        _aSource = GetComponent<AudioSource>();
        _textParent.SetActive(false);
        _isOpen = false;
        _canHide = true;
        LevelManager.instance.OnLevelChange += PlaySentence;
        PlayIntro();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!_isOpen)
            return;

        if (Input.GetButtonDown("Interact") && _canHide)
        {
            Hide();
            onEndSentence.Invoke();
        }
    }

    public void PlayIntro()
    {
        _textParent.SetActive(true);
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
            _canHide = false;

            _aSource.clip = _clips[UnityEngine.Random.Range(0, _clips.Length)];
            _aSource.Play();

            StartCoroutine(DelayHide());
        }
        else
        {
            StartCoroutine(Delay());
        }
    }

    private IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(1);
        _canHide = true;
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