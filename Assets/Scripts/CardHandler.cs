using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHandler : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragAndDrop card = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if (card)
            card.DefaultParent = transform;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        DragAndDrop card = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if (card)
            card.DefaultTempCardParent = transform;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        DragAndDrop card = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if (card && card.DefaultTempCardParent==transform)
            card.DefaultTempCardParent = card.DefaultParent;
    }
}