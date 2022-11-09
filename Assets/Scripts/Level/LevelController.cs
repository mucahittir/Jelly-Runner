using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelData levels;
    public static Level currentLevel;
    public Level CurrentLevel => currentLevel;
    public void Initialize()
    {
        loadLevel();
    }

    public void Reload()
    {
        unloadLevel();
        loadLevel();
    }

    private void loadLevel()
    {
        int i = 0;
        i = (DataManager.Instance.Level - 1) % levels.Count;
        currentLevel = Instantiate(levels[i]);
        currentLevel.Initialize();
        currentLevel.OnActive();
    }

    private void unloadLevel()
    {
        currentLevel.OnDisactive();
        Destroy(currentLevel.gameObject);
        currentLevel = null;
    }
}
