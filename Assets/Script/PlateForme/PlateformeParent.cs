using UnityEngine;

public class PlateformeParent : MonoBehaviour
{
    [SerializeField] private GameObject _particle = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Instantiate(_particle, transform.position - Vector3.up * 0.1f, Quaternion.identity, transform);
        }
    }
}