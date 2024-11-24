using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEarthquake : MonoBehaviour
{
    public float earthquakeStrength = 10f;
    public float earthquakeDuration = 10.0f;
    public float shakeInterval = 0.1f;
    public float startDelay = 5.0f;

    public static bool isEarthquakeActive = false; //For DragHandler use
    private bool isQuaking = false;
    private bool hasQuaked = false;
    private bool debrisKinematicDisabled = false;
    private float quakeTimer = 0.0f;
    private float intervalTimer = 0.0f;
    private float delayTimer = 0.0f;
    private float kinematicDisableTimer = 0.0f;

    public GameObject gameVictoryScreen;

    void Start()
    {
        delayTimer = startDelay;
        if (gameVictoryScreen != null)
        {
            gameVictoryScreen.SetActive(false);
        }

        isEarthquakeActive = false; 
    }

    void Update()
    {
        kinematicDisableTimer += Time.deltaTime;
        if (!debrisKinematicDisabled && kinematicDisableTimer >= 8.0f)
        {
            DisableKinematicOnDebris();
            debrisKinematicDisabled = true;
        }

        if (!isQuaking && !hasQuaked)
        {
            delayTimer -= Time.deltaTime;

            if (delayTimer <= 0)
            {
                isQuaking = true;
                isEarthquakeActive = true; // Set flag to true when the earthquake starts
                quakeTimer = earthquakeDuration;
                intervalTimer = shakeInterval;
            }
        }

        if (isQuaking)
        {
            quakeTimer -= Time.deltaTime;
            intervalTimer -= Time.deltaTime;

            if (intervalTimer <= 0)
            {
                intervalTimer = shakeInterval;
                ApplyRandomForces();
                Debug.Log("Earthquake Has Started");
            }

            if (quakeTimer <= 0)
            {
                isQuaking = false;
                hasQuaked = true;
                Debug.Log("Earthquake Has Stopped");

                if (!LoseLogic.hasLost) // Check if the player has not lost
                {
                    ShowGameVictoryScreen();
                }
            }
        }
    }

    void ApplyRandomForces()
    {
        Rigidbody[] rigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rb in rigidbodies)
        {
            if (rb.CompareTag("Props"))
            {
                Vector3 shake = new Vector3(
                    Random.Range(-earthquakeStrength, earthquakeStrength),
                    0,
                    0
                );
                rb.AddForce(shake, ForceMode.Impulse);
            }
        }
    }

    void DisableKinematicOnDebris()
    {
        GameObject[] debrisObjects = GameObject.FindGameObjectsWithTag("Debris");

        foreach (GameObject debris in debrisObjects)
        {
            Rigidbody rb = debris.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }

        Debug.Log("Disabled Is Kinematic on debris objects");
    }

    void ShowGameVictoryScreen()
    {
        if (gameVictoryScreen != null)
        {
            gameVictoryScreen.SetActive(true);
            Debug.Log("Win Condition Satisfied");
        }
    }
}