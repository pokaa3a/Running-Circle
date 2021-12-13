using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAdmin
{
    public class Status
    {
        public bool ballCanMove = true;
        public bool baseCanMove = false;
    }
    public Status status = new Status();

    public GameStartPage gameStartPage;
    public GameOverPage gameOverPage;
    public Ball ball;
    public MovingBase movingBase;

    private static GameAdmin _instance;
    public static GameAdmin Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameAdmin();
            }
            return _instance;
        }
    }

    private GameAdmin() { }

    // Called when starting a new game. Scenario:
    // 1. Game is just started
    // 2. Game over -> restart a new game of the same level
    // 3. Level completed -> start a new game of next level
    public void InitializeGame()
    {
        // Initialize objects
        gameStartPage.gameObject.SetActive(true);
        gameOverPage.gameObject.SetActive(false);

        ball.Initialize();
        movingBase.Initialize();
        status.ballCanMove = true;
        status.baseCanMove = false;

        // Go to new level
        LevelManager.GoToLevel(1);
    }

    public void StartPlaying()
    {
        gameStartPage.gameObject.SetActive(false);
        status.baseCanMove = true;
    }

    public void GameOver()
    {
        status.ballCanMove = false;
        status.baseCanMove = false;
        gameOverPage.gameObject.SetActive(true);
    }

    public void LevelCompletes()
    {

    }
}
