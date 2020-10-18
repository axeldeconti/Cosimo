using UnityEngine;
using UnityEngine.Events;

public class ActionOnTriggerEnter : MonoBehaviour
{
    public UnityEvent onTriggerEnter = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            onTriggerEnter.Invoke();
    }
}
