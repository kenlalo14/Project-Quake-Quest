using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteHandler : MonoBehaviour
{
    public void OnLevelComplete()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        // Update the LevelProgressionManager
        LevelProgressionManager.Instance.SetCurrentLevel(currentLevelIndex);

        // Load the loading screen
        SceneManager.LoadScene(21);
    }
}