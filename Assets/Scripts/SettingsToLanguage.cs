using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsToLanguage : MonoBehaviour
{
    public void ToLanguage()
    {
        SceneManager.LoadSceneAsync(26);
    }
}
