using UnityEngine;
using UnityEngine.UI;

public class LoseLogic : MonoBehaviour
{
    public GameObject gameOverScreen;
    public static bool hasLost = false; // Flag to check loss condition

    void Start()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("IgnoreColliderPlayer") && collision.gameObject.CompareTag("Debris"))
        {
            ShowGameOverScreen();
            hasLost = true; // Set the loss flag to true
        }
    }

    void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Debug.Log("Lose Condition Satisfied");
        }
    }
}
