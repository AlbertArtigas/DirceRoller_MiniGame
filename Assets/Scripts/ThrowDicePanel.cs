using UnityEngine;
using UnityEngine.EventSystems;
public class ThrowDicePanel : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            REFS.DICE_HOLDER_GHOST.gameObject.SetActive(false);
            Destroy(eventData.pointerDrag.gameObject);
            REFS.THROW_DIE_SCRIPT.ThrowDice(1, true); 

            REFS.SWIPE_MANAGER.isDragging = false;
            REFS.DICE_THROW_BUTTON.interactable = true;
            REFS.DICE_THROW_BUTTON.blocksRaycasts = true;
        }              
    }
}
