using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C1Level3Complete : MonoBehaviour
{
    public void toLevelSelection()
    {
        FindObjectOfType<LevelCompletion>().MarkLevelCleared(3);

        SceneManager.LoadScene(22);
    }
}