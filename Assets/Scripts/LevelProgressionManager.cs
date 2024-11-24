using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgressionManager : MonoBehaviour
{
    public static LevelProgressionManager Instance;

    private int currentLevelIndex = 1; 
    public int maxLevels = 20; 

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Stay across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCurrentLevel(int levelIndex)
    {
        currentLevelIndex = levelIndex;
    }

    public int GetNextLevelIndex()
    {
        return currentLevelIndex + 1; // Increment level
    }

    public void LoadNextLevel()
    {
        int nextLevel = GetNextLevelIndex();
        if (nextLevel <= maxLevels) // Ensure level exists
        {
            SceneManager.LoadScene(nextLevel);
        }
        else
        {
            Debug.Log("All levels completed!");
            SceneManager.LoadScene(0); // Direct to main menu for now
        }
    }
}
