using System.Collections;
using UnityEngine;

public class Mongolfiere : MonoBehaviour
{
    [SerializeField] private AnimationCurve _mouvementCurve = null;
    [SerializeField] private float _time = 0;
    [SerializeField] private float _maxHeight = 0;

    private Vector3 _pos = Vector3.zero;

    public void Fly()
    {
        _pos = transform.position;

        StartCoroutine(FlyCoroutine());
    }

    public IEnumerator FlyCoroutine()
    {
        float currentTime = 0f;
        float percent = 0f;
        float value = 0f;

        while (currentTime < _time)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / _time;
            value = _mouvementCurve.Evaluate(percent);

            transform.position = _pos + Vector3.up * value * _maxHeight;

            yield return null;
        }
    }
}