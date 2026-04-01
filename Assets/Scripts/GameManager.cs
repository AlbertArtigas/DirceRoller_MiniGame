using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int TotalDiceCount = 6;
    public static int DiceLeft = 0;

    public static int TotalScore = 0;

    void Start()
    {
        DiceLeft = TotalDiceCount;
        REFS.UI_MANAGER.UpdateDiceLeft();
    }

    public static void UpdateDiceLeft(int change)
    {
        DiceLeft += change;
        if(DiceLeft < 0) DiceLeft = 0;
        else if(DiceLeft > TotalDiceCount) DiceLeft = TotalDiceCount;

        REFS.UI_MANAGER.UpdateDiceLeft();
    }

    public static void ResetGame()
    {
        DiceLeft = TotalDiceCount;
        TotalScore = 0;
        REFS.UI_MANAGER.UpdateDiceLeft();
        REFS.UI_MANAGER.UpdateScore();
        REFS.MISSION_MANAGER.resetGame();
        REFS.SWIPE_MANAGER.timedOut = false;

    }

    public void Quit()
    {
        Application.Quit();
    }

    public static void UpdateScore(int score)
    {
        TotalScore += score;
        REFS.UI_MANAGER.UpdateScore();
    }

    public static void GameOver()
    {
        REFS.UI_MANAGER.GameOverScreen();
    }

    public void RetryButton()
    {
        REFS.THROW_DIE_SCRIPT.ClearDice();
        REFS.UI_MANAGER.ClearDicePanel();
        REFS.UI_MANAGER.Retry();
        ResetGame();
    }
    
    
}
