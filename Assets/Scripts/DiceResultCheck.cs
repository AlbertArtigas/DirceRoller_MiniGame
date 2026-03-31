using TMPro;
using UnityEngine;

public class DiceResultCheck : MonoBehaviour
{
    public GameObject resultDisplay;
    GameObject display;
    public Transform faceCols;
    public Rigidbody rb;
    public int result;
    bool resultDisplayed = false;
    float timer = 0f;
    float diceTimeOut = 5f;

    void Update()
    {
        if (rb.linearVelocity.magnitude < 0.01f)
        {
            faceCols.gameObject.SetActive(true);
            resultDisplayed = true;

            //Reroll cocked dice
            if(result == 0) timer += Time.deltaTime;
            else timer = 0f;
                
            if(timer > diceTimeOut) KillDice();
           
        }
        else if (resultDisplayed) //safety: just not to destroy the display before it apears for the first time
        {
            faceCols.gameObject.SetActive(false);
            HideResultDisplay();
        }
    }

    // Called by the face colliders when the die is still
    public void CheckResult(string faceName)
    {
        result = int.Parse(faceName);
        DisplayResult();    
        REFS.THROW_DIE_SCRIPT.diceResults[gameObject] = result;    
    }

    void DisplayResult()
    {
        display = Instantiate(resultDisplay, transform.position, Quaternion.identity);
        display.GetComponentInChildren<TextMeshPro>().text = result.ToString();
        REFS.THROW_DIE_SCRIPT.RefreshDiceResults();
    }

    void HideResultDisplay()
    {       
        Destroy(display); 
        REFS.THROW_DIE_SCRIPT.RefreshDiceResults();
    }

    void OnDestroy()
    {
        HideResultDisplay();
        REFS.THROW_DIE_SCRIPT.diceResults.Remove(gameObject);
    }

    public void KillDice()
    {
        GameManager.UpdateDiceLeft(1);
        Destroy(gameObject); 
    }
}
