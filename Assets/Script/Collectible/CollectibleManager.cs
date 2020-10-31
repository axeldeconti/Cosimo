using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    private void Start()
    {
        LevelManager.instance.OnLevelChange += ChangeLevel;
    }

    private void ChangeLevel(int level)
    {
        if (level == 6)
            return;

        if(transform.childCount > 1)
            Destroy(transform.GetChild(1).gameObject);
    }
}