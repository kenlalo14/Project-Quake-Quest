using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C2Level5Complete : MonoBehaviour
{
    public void toLevelSelection() 
    {
        FindObjectOfType<LevelCompletion>().MarkLevelCleared(5);

        SceneManager.LoadScene(22);
    }
}
