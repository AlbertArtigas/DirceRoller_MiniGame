using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThrowDie : MonoBehaviour
{
    public GameObject die;
    public UIManager UIManager;
    public int numberOfDice;    

    public Dictionary<GameObject, int> diceResults = new Dictionary<GameObject, int>();

    public void ThrowDiceButton()
    {
        ThrowDice(numberOfDice, inHand: false);
    }
    public void ThrowDice(int nDice, bool inHand)
    {
        StartCoroutine(Throw(nDice, inHand));
    }
    IEnumerator Throw(int numberOfDice, bool inHand)
    {
        if(!inHand && GameManager.DiceLeft <= 0) yield break;

        for(int i = 0; i < numberOfDice; i++)
        {
            GameObject newDie = Instantiate(die, transform.position, Quaternion.identity);
            diceResults.Add(newDie, 0);
            float t = UnityEngine.Random.Range(0.0f, 0.2f);

            if(!inHand)
            {
                GameManager.UpdateDiceLeft(-1);
                if(GameManager.DiceLeft <= 0) break;
            }
            
            yield return new WaitForSeconds(t);   
        }
    }
    public void ClearDice()
    {
        foreach(GameObject die in diceResults.Keys)
        {
            Destroy(die);
        }
        diceResults.Clear();
    }

    public void RefreshDiceResults()
    {
        for (int i = 0; i < diceResults.Count; i++)
        {
            diceResults[diceResults.Keys.ElementAt(i)] = diceResults.Values.ElementAt(i);
        }

    } 

    public void DEBUG_printDict()
    {
        for (int i = 0; i < diceResults.Count; i++)
        {
            print(diceResults.Keys.ElementAt(i).name + "--> Value: " + diceResults.Values.ElementAt(i));
        }

    }

}
