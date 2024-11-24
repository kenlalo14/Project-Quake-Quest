using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C4Level13Complete : MonoBehaviour
{
    public void toLevelSelection() 
    {
        FindObjectOfType<LevelCompletion>().MarkLevelCleared(13);

        SceneManager.LoadScene(22);
    }
}
