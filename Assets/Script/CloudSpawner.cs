using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _boxSize = Vector2.zero;
    [SerializeField] private GameObject[] _cloudPrefabs = null;
    [SerializeField] private Vector2 _spawnInterval = Vector2.zero;
    [SerializeField] private float _destroyDistance = 0f;

    private float _nextTimeToSpawn = 0;

    private Vector3 _destroyPos => transform.position + Vector3.right * _destroyDistance;

    private void Update()
    {
        if (_nextTimeToSpawn <= Time.time)
        {
            _nextTimeToSpawn = Time.time + Random.Range(_spawnInterval.x, _spawnInterval.y);
            Vector3 pos = new Vector3(Random.Range(transform.position.x - _boxSize.x, transform.position.x + _boxSize.x), Random.Range(transform.position.y - _boxSize.y, transform.position.y + _boxSize.y), 1);
            Instantiate(_cloudPrefabs[Random.Range(0, _cloudPrefabs.Length)], pos, Quaternion.identity, transform).GetComponent<Cloud>().destroyPos = _destroyPos;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, _boxSize);
        Gizmos.DrawWireSphere(_destroyPos, 1f);
    }
}
