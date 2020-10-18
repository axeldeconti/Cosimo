using Cinemachine;
using System.Collections;
using UnityEngine;

public class DollyCamManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cam = null;
    [SerializeField] private float _time = 0;
    [SerializeField] private AnimationCurve _movementSpeed = null;

    private CinemachineTrackedDolly _dolly = null;
    private int _currentLevel = 0;

    private void Start()
    {
        LevelManager.instance.OnLevelChange += ChangeLevel;
        _dolly = _cam.GetCinemachineComponent<CinemachineTrackedDolly>();
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
    }
}
