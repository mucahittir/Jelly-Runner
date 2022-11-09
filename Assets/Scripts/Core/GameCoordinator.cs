using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoordinator : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] LevelController levelController;
    public void Initialize()
    {
        playerController.Initialize();
        levelController.Initialize();

    }
    public void StartGame()
    {
        playerController.StartGame();
    }
    public void Reload()
    {
        playerController.Reload();
        levelController.Reload();
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
