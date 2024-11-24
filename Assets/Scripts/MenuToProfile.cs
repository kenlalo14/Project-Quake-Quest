using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToProfile : MonoBehaviour
{
    public void ToProfile() 
    {
        SceneManager.LoadSceneAsync(24);
    }
}
