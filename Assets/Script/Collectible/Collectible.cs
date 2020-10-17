using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField] private GameObject _collectibleUI = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Player is touched
            GameObject col = Instantiate(_collectibleUI, transform.position, Quaternion.identity);
            col.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
        }
    }
}