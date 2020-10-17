using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    [SerializeField] private GameObject _indicationParent = null;
    [SerializeField] private bool _isActive = false;
    [SerializeField] private bool _isDone = false;

    public UnityEvent onInteract = null;

    private void Start()
    {
        _isActive = false;
        _isDone = false;
        _indicationParent.SetActive(false);
    }

    private void Update()
    {
        if (!_isActive)
            return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            onInteract.Invoke();
            _isDone = true;
            _isActive = false;
            _indicationParent.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isDone)
        {
            _isActive = true;
            _indicationParent.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isDone)
        {
            _isActive = false;
            _indicationParent.SetActive(false);
        }
    }
}