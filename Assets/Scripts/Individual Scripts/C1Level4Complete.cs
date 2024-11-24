using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C1Level4Complete : MonoBehaviour
{
    public void toLevelSelection()
    {
        FindObjectOfType<LevelCompletion>().MarkLevelCleared(4);

        SceneManager.LoadScene(22);
    }
}