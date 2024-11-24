using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C2Level8Complete : MonoBehaviour
{
    public void toLevelSelection() 
    {
        FindObjectOfType<LevelCompletion>().MarkLevelCleared(8);

        SceneManager.LoadScene(22);
    }
}
