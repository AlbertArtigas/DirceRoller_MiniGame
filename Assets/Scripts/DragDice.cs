using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DragDice : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Canvas canvas;
    RectTransform diceHolderPanel;
    HorizontalLayoutGroup horizontalLayoutGroup;
    GameObject diceIconGhost;
    [SerializeField]private int siblingIndex;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private CanvasGroup canvasGroup;
    void Awake()
    {           
        canvas = REFS.MAIN_CANVAS;
        diceHolderPanel = REFS.DICE_PANEL.GetComponent<RectTransform>();
        horizontalLayoutGroup = REFS.DICE_PANEL.GetComponent<HorizontalLayoutGroup>();
        diceIconGhost = REFS.DICE_HOLDER_GHOST.gameObject;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        int sibIndex = rectTransform.GetSiblingIndex();
        REFS.DICE_THROW_BUTTON.interactable = false;
        REFS.DICE_THROW_BUTTON.blocksRaycasts = false;

        rectTransform.SetParent(canvas.transform);
        rectTransform.localScale *= 1.2f;
        canvasGroup.blocksRaycasts = false;

        diceIconGhost.transform.SetSiblingIndex(sibIndex);
        diceIconGhost.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;

        float diceWith = rectTransform.rect.width;
        float betweenMargin = horizontalLayoutGroup.spacing;
        float groupLMargin = horizontalLayoutGroup.padding.left;
        float panelLeftEdge = diceHolderPanel.anchoredPosition.x;

        float initialMargin = panelLeftEdge + groupLMargin + diceWith/2;
        float offset = betweenMargin + diceWith;
        
        siblingIndex = Mathf.RoundToInt((rectTransform.position.x - initialMargin)/offset);
        diceIconGhost.transform.SetSiblingIndex(siblingIndex);
    
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        rectTransform.localScale /= 1.2f;
        canvasGroup.blocksRaycasts = true;
        REFS.DICE_THROW_BUTTON.interactable = true;
        REFS.DICE_THROW_BUTTON.blocksRaycasts = true;
    }

}
