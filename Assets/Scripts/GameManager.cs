using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int TotalDiceCount = 6;
    public static int DiceLeft = 0;

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
        REFS.UI_MANAGER.UpdateDiceLeft();
    }

    public void Quit()
    {
        Application.Quit();
    }
    
}
