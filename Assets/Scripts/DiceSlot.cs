using UnityEngine;
using UnityEngine.EventSystems;

public class DiceSlot : MonoBehaviour, IDropHandler
{
    public GameObject diceIconGhost;
    public void OnDrop(PointerEventData eventData)
    {
        int sibIndex = diceIconGhost.transform.GetSiblingIndex();
        diceIconGhost.SetActive(false);

        if(eventData.pointerDrag != null)
             eventData.pointerDrag.GetComponent<RectTransform>().SetParent(transform);
             eventData.pointerDrag.GetComponent<RectTransform>().SetSiblingIndex(sibIndex);
             
    }
}
