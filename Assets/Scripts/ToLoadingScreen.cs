using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLoadingScreen : MonoBehaviour
{
    public void toLoading() 
    {
        SceneManager.LoadSceneAsync(23);
    }
}
