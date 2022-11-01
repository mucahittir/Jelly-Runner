using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAgent player;
    InputController inputController;

    public void Initialize()
    {
        player.Initialize();
        inputController = new InputController();
    }

    public void StartGame()
    {
        player.StartGame();
    }

    public void Reload()
    {
        player.Reload();
    }

    public void GameOver()
    {
        player.GameOver();
    }

    public void GameSuccess()
    {
        player.GameSuccess();
    }

    private void Update()
    {
        inputController.CustomUpdate();

        player.Movement(inputController.GetValue().x);
    }

}
