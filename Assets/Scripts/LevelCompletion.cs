using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    public void MarkLevelCleared(int levelNumber)
    {
        int highestLevelUnlocked = PlayerPrefs.GetInt("HighestLevelUnlocked", 1);

        // Unlock the next level if this is the highest so far
        if (levelNumber >= highestLevelUnlocked)
        {
            PlayerPrefs.SetInt("HighestLevelUnlocked", levelNumber + 1); // Unlock the next level
            PlayerPrefs.Save(); // Save progress to disk
        }
    }
}
