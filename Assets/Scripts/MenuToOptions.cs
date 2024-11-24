using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToOptions : MonoBehaviour
{
    public void ToOptions() 
    {
        SceneManager.LoadSceneAsync(25);
    }
}
