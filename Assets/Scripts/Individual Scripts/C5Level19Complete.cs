using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class C5Level19Complete : MonoBehaviour
{
    public void toLevelSelection() 
    {
        FindObjectOfType<LevelCompletion>().MarkLevelCleared(19);

        SceneManager.LoadScene(22);
    }
}
