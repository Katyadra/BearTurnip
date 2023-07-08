using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragAndDrop card = eventData.pointerDrag.GetComponent<DragAndDrop>();
        if (card)
            card.DefaultParent = transform;
    }
}