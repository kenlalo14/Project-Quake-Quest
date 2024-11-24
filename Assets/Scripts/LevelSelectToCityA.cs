using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectToCityA : MonoBehaviour
{
    public void SelectCityA() 
    {
        SceneManager.LoadSceneAsync(23);
    }
}
