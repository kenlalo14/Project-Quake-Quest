using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C2Level7Complete : MonoBehaviour
{
    public void toLevelSelection() 
    {
        FindObjectOfType<LevelCompletion>().MarkLevelCleared(7);

        SceneManager.LoadScene(22);
    }
}
