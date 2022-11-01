using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    public void Initialize()
    {
        playerController.Initialize();

    }
    public void StartGame()
    {
        playerController.StartGame();
    }
    public void Reload()
    {
        playerController.Reload();
    }

    public void GameSuccess()
    {

        playerController.GameSuccess();
    }

    public void GameOver()
    {
        playerController.GameOver();
    }

}
