using Cinemachine;
using System.Collections;
using UnityEngine;

public class DollyCamManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cam = null;
    [SerializeField] private float _time = 0;
    [SerializeField] private AnimationCurve _movementSpeed = null;
    [SerializeField] private GameObject _rightEdge = null;

    [Header("Mongolfiere")]
    [SerializeField] private Mongolfiere _mongolfiere = null;
    [SerializeField] private AnimationCurve _mouvementCurve = null;
    [SerializeField] private float _mongolfiereTime = 0;
    [SerializeField] private float _maxHeight = 0;

    private CinemachineTrackedDolly _dolly = null;
    private int _currentLevel = 0;
    private Vector3 _pathOffset = Vector3.zero;

    private void Start()
    {
        LevelManager.instance.OnLevelChange += ChangeLevel;
        _dolly = _cam.GetCinemachineComponent<CinemachineTrackedDolly>();
        _pathOffset = _dolly.m_PathOffset;
    }

    private void ChangeLevel(int level)
    {
        StartCoroutine(ChangeLevelCoroutine(level));
    }

    private IEnumerator ChangeLevelCoroutine(int level)
    {
        float time = 0;
        float percent = 0;
        float currentValue = 0;
        
        while (time < _time)
        {
            percent = time / _time;
            currentValue = _movementSpeed.Evaluate(percent) + _currentLevel;
            _dolly.m_PathPosition = currentValue;

            time += Time.deltaTime;
            yield return null;
        }

        _currentLevel = level;

        if (_currentLevel == 5)
            _rightEdge.SetActive(false);
        else if(_currentLevel == 6)
        {
            Debug.Log("Fly");
            _mongolfiere.Fly();
            StartCoroutine(FlyCoroutine());
        }
    }

    public IEnumerator FlyCoroutine()
    {
        float currentTime = 0f;
        float percent = 0f;
        float value = 0f;

        while (currentTime < _mongolfiereTime)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / _mongolfiereTime;
            value = _mouvementCurve.Evaluate(percent);

            _dolly.m_PathOffset = _pathOffset + Vector3.up * value * _maxHeight;

            yield return null;
        }
    }
}
