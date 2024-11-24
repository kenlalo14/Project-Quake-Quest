using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public TMP_Text tipText; 
    public TMP_Text loadingText; 
    public Button continueButton; 
    public int maxLevels = 20;

    void Start()
    {
        DisplayRandomTip();
        continueButton.gameObject.SetActive(false); 
        Invoke(nameof(ActivateButtonAndHideLoading), 5f); 
    }

    void DisplayRandomTip()
    {
        string[] tips = new string[]
        {
            "If you can't find a sturdy cover, stay close to the buildings' pillars or central part of the building.",
            "Remember to Duck, Cover, and Hold on.",
            "During an Earthquake immediately look for sturdy tables or desks.",
            "If you are far from a furniture to cover yourself, find something to block your head and raise it overhead.",
            "Do not attempt to escape while the tremors are still ongoing."
        };

        tipText.text = tips[Random.Range(0, tips.Length)];
    }

    void ActivateButtonAndHideLoading()
    {
        continueButton.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(false);
    }

    public void OnContinueButtonPressed()
    {
        int nextLevel = LevelProgressionManager.Instance.GetNextLevelIndex();

        if (nextLevel <= maxLevels) // For ensuring the next level is within bounds
        {
            LevelProgressionManager.Instance.LoadNextLevel();
        }
        else
        {
            Debug.Log("All levels done. Redirecting to main menu.");
            SceneManager.LoadScene("VictoryScreen");
        }
    }
}