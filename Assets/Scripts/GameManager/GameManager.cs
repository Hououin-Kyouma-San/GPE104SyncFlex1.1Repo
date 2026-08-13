using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Keeps track of Player Pawn
    public StarShipPawn playerPawn;

    // Keeps track of list of Meteors
    public List<DeathMeteor> meteors;

    // Game States
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsScreenStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverStateObject;

    private void Awake()
    {
        meteors = new List<DeathMeteor>();

        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivateTitleScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPawn == null)
        {
            Debug.Log("Failure");
        }
        else if (playerPawn != null && meteors.Count == 0)
        {
            Debug.Log("Victory");
        }
    }

    // Deactivates all screen objects
    private void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsScreenStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverStateObject.SetActive(false);
    }

    // Activates title screen
    public void ActivateTitleScreen()
    {
        DeactivateAllStates();

        TitleScreenStateObject.SetActive(true);
    }

    // Activates main menu screen
    public void ActivateMainMenuScreen()
    {
        DeactivateAllStates();

        MainMenuStateObject.SetActive(true);
    }

    // Activates options screen
    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();

        OptionsScreenStateObject.SetActive(true);
    }

    // Activates credits screen
    public void ActivateCreditsScreen()
    {
        DeactivateAllStates();

        CreditsScreenStateObject.SetActive(true);
    }

    // Activates Gameplay screen
    public void ActivateGameplayScreen()
    {
        DeactivateAllStates();

        GameplayStateObject.SetActive(true);

        // Do anything else to get our game to run

        // TODO: Return to implement fully
    }

    // Activates game over screen
    public void ActivateGameOverScreen()
    {
        DeactivateAllStates();

        GameOverStateObject.SetActive(true);
    }
}