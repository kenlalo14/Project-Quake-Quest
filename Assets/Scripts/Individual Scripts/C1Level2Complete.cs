using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C1Level2Complete : MonoBehaviour
{
    public void toLevelSelection()
    {
        FindObjectOfType<LevelCompletion>().MarkLevelCleared(2);

        SceneManager.LoadScene(22);
    }
}