using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityAToLevel1 : MonoBehaviour
{
    public void ToLevel1() 
    {
        SceneManager.LoadSceneAsync(1);
    }
}
