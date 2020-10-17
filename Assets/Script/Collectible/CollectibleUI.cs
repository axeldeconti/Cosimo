using System.Collections;
using UnityEngine;

public class CollectibleUI : MonoBehaviour
{
    [SerializeField] private float _growthTime = 1f;
    [SerializeField] private AnimationCurve _growthCurve = null;

    [Space]
    [SerializeField] private float _movementTime = 1f;
    [SerializeField] private AnimationCurve _movementCurve = null;

    private void Start()
    {
        StartCoroutine(StartMovement());
    }

    private IEnumerator StartMovement()
    {
        float time = 0;
        float percent = 0;
        float currentValue = 0;

        //Growth
        while(time < _growthTime)
        {
            percent = time / _growthTime;
            currentValue = _growthCurve.Evaluate(percent);
            transform.localScale = Vector3.one * currentValue;

            time += Time.deltaTime;
            yield return null;
        }

        time = 0;
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3 originalPos = rectTransform.position;
        Vector3 dir = (CollectibleUITarget.instance.rectTransform.position - originalPos).normalized;
        float mag = (CollectibleUITarget.instance.rectTransform.position - originalPos).magnitude;

        //Movement
        while (time < _movementTime)
        {
            percent = time / _movementTime;
            currentValue = _movementCurve.Evaluate(percent);
            rectTransform.position = originalPos + dir * currentValue * mag;

            time += Time.deltaTime;
            yield return null;
        }
    }
}
