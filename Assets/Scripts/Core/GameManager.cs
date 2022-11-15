using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : CoreObj<GameManager>
{
    [SerializeField] GameCoordinator gameCoordinator;
    public GameState gameState;
    public override void Initialize()
    {
        setIdleState();
        gameCoordinator.Initialize();

        UIManager.Instance.UpdateUIElements();
    }

    public void StartGame()
    {
        setInGameState();
        gameCoordinator.StartGame();
    }

    public void Reload()
    {
        setIdleState();
        gameCoordinator.Reload();
        resetStatics();
        UIManager.Instance.UpdateUIElements();
    }

    public void GameOver()
    {
        setGameOverState();
        gameCoordinator.GameOver();
    }

    public void GameSuccess()
    {
        setGameSuccessState();
        playerProgress();
        gameCoordinator.GameSuccess();
    }

    private void playerProgress()
    {
        DataManager.Instance.Level++;
        DataManager.Instance.Save();
    }

    private void setIdleState()
    {
        gameState = GameState.Idle;
        UIManager.Instance.OpenUIClean("IdleScreen");
    }

    private void setInGameState()
    {
        gameState = GameState.InGame;
        UIManager.Instance.OpenUIClean("GameplayScreen");
    }

    private void setGameOverState()
    {
        gameState = GameState.GameOver;
        UIManager.Instance.OpenUIClean("FailScreen");
    }
    private void setGameSuccessState()
    {

        gameState = GameState.GameOver;
        UIManager.Instance.OpenUIClean("SuccessScreen");
    }

    private void resetStatics()
    {
        COMMONS.ResetValues();
    }
}
public enum GameState : int
{
    Idle = 0,
    InGame = 1,
    GameOver = 2
}