using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Keeps track of Player Pawn
    public StarShipPawn playerPawn;

    // Keeps track of list of Meteors
    public List<DeathMeteor> meteors;

    // Game states
    public GameObject GameplayStateObject;
    public GameObject GameOverStateObject;

    private void Awake()
    {
        meteors = new List<DeathMeteor>();

        if (instance == null) 
        {
            instance = this;

            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateGameplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPawn != null && playerPawn.isActiveAndEnabled == false)
        {
            Debug.Log("Failure");

            // Create timer coroutine
            StartCoroutine(timer());
            IEnumerator timer()
            {
                // Set timer delay
                yield return new WaitForSeconds(3);
                ActivateGameOverScreen();
            }
        }
        else if (playerPawn != null && meteors.Count == 0)
        {
            Debug.Log("Victory");
        }
    }

    // Deactivates all screen objects
    private void DeactivateAllStates()
    {
        if (GameplayStateObject != null)
        {
            GameplayStateObject.SetActive(false);
        }
        if (GameOverStateObject != null)
        {
            GameOverStateObject.SetActive(false);
        }
    }

    // Activates Gameplay screen
    public void ActivateGameplay()
    {
        DeactivateAllStates();

        GameplayStateObject.SetActive(true);
    }

    // Activates game over screen
    public void ActivateGameOverScreen()
    {
        //GameOverStateObject.SetActive(true);
        DeactivateAllStates();

        if (GameOverStateObject == isActiveAndEnabled && playerPawn != null)
        {
            SceneManager.UnloadSceneAsync(3);
            SceneManager.LoadScene(4);
        }
    }
}