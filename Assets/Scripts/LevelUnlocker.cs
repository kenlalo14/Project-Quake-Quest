using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Button[] levelButtons; // Assign ALL 20 buttons in order (City1 Level 1 → City5 Level 4)

    void Start()
    {
        int highestLevelUnlocked = PlayerPrefs.GetInt("HighestLevelUnlocked", 1);

        // Loop through all level buttons and enable/disable based on progression
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i + 1) <= highestLevelUnlocked;
        }
    }
}