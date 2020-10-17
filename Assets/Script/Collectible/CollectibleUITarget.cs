using UnityEngine;

public class CollectibleUITarget : MonoBehaviour
{
    public static CollectibleUITarget instance = null;

    public RectTransform rectTransform => GetComponent<RectTransform>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
}
