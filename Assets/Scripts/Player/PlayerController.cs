using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerAgent player;
    InputController inputController;

    bool isActive;

    public void Initialize()
    {
        player.Initialize();
        inputController = new InputController();
        inputController.OnTap = onTap;
        isActive = false;
    }

    public void StartGame()
    {
        player.StartGame();
        isActive = true;
    }

    public void Reload()
    {
        player.Reload();
    }

    public void GameOver()
    {
        player.GameOver();
        isActive = false;
    }

    public void GameSuccess()
    {
        player.GameSuccess();
        isActive = false;
    }

    private void onTap()
    {
        player.ChangeMode();
    }

    private void Update()
    {
        if(isActive)
        {
            inputController.CustomUpdate();
            player.Movement(inputController.Value.x);
        }
    }

}
