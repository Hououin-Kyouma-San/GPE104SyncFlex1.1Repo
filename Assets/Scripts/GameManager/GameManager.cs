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
}