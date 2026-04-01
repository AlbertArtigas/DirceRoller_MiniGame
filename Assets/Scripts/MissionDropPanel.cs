using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MissionDropPanel : MonoBehaviour, IDropHandler
{
    public Mission mission;
    public TextMeshProUGUI missionText;
    public TextMeshProUGUI diceLeftText;
    public Image slotImage;
    public Slider timeDisplay;
    public TextMeshProUGUI pointsText;
    bool gameOver = false;

    int diceleft;

    List<Sprite> allowedDiceSprites = new List<Sprite>();
    List<int> allowedValues = new List<int>();

    void Start()
    {
        missionText.text = mission.missionText;

        diceleft = mission.diceAmount;
        diceLeftText.text = diceleft.ToString();
        StartCoroutine(RotateImageDisplay());
        pointsText.text = mission.points.ToString();
        
        timeDisplay.maxValue = mission.time;
        timeDisplay.value = mission.time;


        for(int i= 0; i < mission.allowedDice.Count; i++)
        {
            allowedDiceSprites.Add(mission.allowedDice[i].GetComponent<Image>().sprite);
            allowedValues.Add(mission.allowedDice[i].GetComponent<DragDice>().value);
        }
    }

    void Update()
    {
        timeDisplay.value -= Time.deltaTime;
        if(timeDisplay.value <= 0 && !gameOver)
        {
            gameOver = true;
            GameManager.GameOver();
        }
    }

    IEnumerator RotateImageDisplay()
    {
        
        
        yield return new WaitForSeconds(1);        
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(allowedValues.Contains(eventData.pointerDrag.GetComponent<DragDice>().value))
        {
            if(slotImage.transform.childCount > 0) Destroy(slotImage.transform.GetChild(0).gameObject);
            eventData.pointerDrag.GetComponent<RectTransform>().position = slotImage.GetComponent<RectTransform>().position;
            eventData.pointerDrag.transform.SetParent(slotImage.transform);

            CanvasGroup cv = eventData.pointerDrag.GetComponent<CanvasGroup>();
            cv.interactable = false;
            cv.blocksRaycasts = false;
            cv.alpha = .5f;

            REFS.DICE_HOLDER_GHOST.gameObject.SetActive(false);

            diceleft --;
            if(diceleft == 0)
            {
                Debug.Log("Mission Complete");
                GameManager.UpdateScore(mission.points);  
                REFS.MISSION_MANAGER.NextMission();              
                Destroy(gameObject);
            }
            diceLeftText.text = diceleft.ToString();
        }
        else
        {
            Debug.Log("Dice Denied");            
            eventData.pointerDrag.transform.SetParent(REFS.DICE_PANEL);
            eventData.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
            REFS.DICE_HOLDER_GHOST.gameObject.SetActive(false);
        }
             
    }
}
