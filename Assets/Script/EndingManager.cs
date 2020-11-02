using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField] private GameObject _parent = null;

    private bool _canEnd = false;
    private bool _isShown = false;

    private void Start()
    {
        _canEnd = false;
        _isShown = false;
        _parent.SetActive(false);
    }

    private void Update()
    {
        if (!_canEnd || !_isShown)
            return;

        if (Input.GetButtonDown("Interact"))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    public void CanEnd(bool value)
    {
        _canEnd = value;
    }

    public void Show()
    {
        _isShown = true;
        _parent.SetActive(true);
    }
}