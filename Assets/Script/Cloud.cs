using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] private Vector2 _speedLimits = Vector2.zero;

    private float _speed = 0;

    public Vector3 destroyPos = Vector3.zero;

    private void Start()
    {
        _speed = Random.Range(_speedLimits.x, _speedLimits.y);
    }

    private void Update()
    {
        transform.position += Vector3.right * _speed / 1000;

        if (transform.position.x >= destroyPos.x)
            Destroy(gameObject);
    }
}
