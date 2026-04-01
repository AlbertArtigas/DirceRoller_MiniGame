using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI diceLeftText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI GOScoreText;
    public TextMeshProUGUI GOTotalMissions;

    public TMP_InputField nDiceInput;
    public ThrowDie throwDieScript;


    public Transform dicePanel;
    [Header("Dice Images")]    
    public GameObject Icon1;
    public GameObject Icon2; 
    public GameObject Icon3;
    public GameObject Icon4;
    public GameObject Icon5;
    public GameObject Icon6;
    void Start()
    {
        throwDieScript.numberOfDice = 1;
        nDiceInput.text = "1";
        nDiceInput.characterValidation = TMP_InputField.CharacterValidation.Integer;

    }   
    public void DiceUp()
    {
        throwDieScript.numberOfDice++;
        nDiceInput.text = throwDieScript.numberOfDice.ToString();
    }
    public void DiceDown()
    {
        if(throwDieScript.numberOfDice == 1)
            return;
        throwDieScript.numberOfDice--;
        nDiceInput.text = throwDieScript.numberOfDice.ToString();        
    }
    public void SetDiceNumber()
    {        
        throwDieScript.numberOfDice = int.Parse(nDiceInput.text);
    }
    public void FillDicePanel()
    {
        StartCoroutine(FillDicePanelCoroutine());
    }
    IEnumerator FillDicePanelCoroutine()
    {   
        int diceCount = throwDieScript.diceResults.Count;
        
        for(int i = diceCount - 1; i >= 0; i--)
        {
            GameObject currentDie = throwDieScript.diceResults.Keys.ElementAt(i);
            int currentDieValue = throwDieScript.diceResults[currentDie];

            if(currentDieValue == 0)  continue;

            GameObject diceIcon = null;
            switch (currentDieValue)
            {
                case 1:
                    diceIcon = Icon1;
                    break;
                case 2:
                    diceIcon = Icon2;
                    break;
                case 3:
                    diceIcon = Icon3;
                    break;
                case 4:
                    diceIcon = Icon4;
                    break;
                case 5:
                    diceIcon = Icon5;
                    break;
                case 6:
                    diceIcon = Icon6;
                    break;                
            }
            GameObject icon = Instantiate(diceIcon, dicePanel);
            icon.GetComponent<DragDice>().value = currentDieValue;
            Destroy(currentDie);
            throwDieScript.diceResults.Remove(currentDie);
            yield return new WaitForSeconds(.05f);
        }
    
    }
    public void ClearDicePanel()
    {
        for (int i = dicePanel.childCount - 1; i >= 0 ; i--)
        {
            if(dicePanel.GetChild(i).name == "DiceIconGhost") continue;
            Destroy(dicePanel.GetChild(i).gameObject);            
        }
    }
    public void UpdateDiceLeft()
    {
        diceLeftText.text = GameManager.DiceLeft.ToString();    
    }
    internal void UpdateScore()
    {
        scoreText.text = GameManager.TotalScore.ToString();
    }

    public void GameOverScreen()
    {
        gameOverPanel.SetActive(true);
        GOScoreText.text = GameManager.TotalScore.ToString();
        GOTotalMissions.text = "1"; //TODO: Count Missions and display here.
    }
    public void Retry()
    {
        gameOverPanel.SetActive(false);
    }

    


}
