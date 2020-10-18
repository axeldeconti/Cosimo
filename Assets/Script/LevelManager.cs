using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Instance
    public static LevelManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    public Action<int> OnLevelChange = null;

    private int _currentLevel = 0;

    private void Start()
    {
        _currentLevel = 0;
    }

    public void ChangeLevel()
    {
        _currentLevel++;
        Debug.Log("Level Mgr : change to level " + _currentLevel);
        OnLevelChange?.Invoke(_currentLevel);
    }
}