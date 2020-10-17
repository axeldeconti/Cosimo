using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject _collectibleUI = null;
    [SerializeField] private Transform _collectibleParent = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Player is touched
            Debug.Log("Collected");
            GameObject col = Instantiate(_collectibleUI, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity, _collectibleParent);
            col.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
            Destroy(gameObject);
        }
    }
}