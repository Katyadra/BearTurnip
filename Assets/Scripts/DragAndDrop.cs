using UnityEngine.EventSystems;
using UnityEngine;
using static DragAndDrop;
using System.Collections.Generic;
using System;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public interface ICardHandler : IEventSystemHandler
    {
        void OnCardOver(Transform card);
        void OnCardOut(Transform card);
        void OnCardDrop(Transform card);
    }


    public Transform draggingParent;
    public RectTransform playArea;
    public Transform myCards; // ссылка на вашу область MyCards
    public Transform hand; // ссылка на вашу область Hand
    private Vector3 startPosition;
    private Transform startParent;
    private ICardHandler overCard;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = rectTransform.position;
        startParent = transform.parent;
        transform.SetParent(draggingParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ѕозици€ мыши в пространстве Canvas
        Vector2 mousePositionInCanvas = eventData.position;
        // ѕозици€ мыши в пространстве Stol
        Vector2 mousePositionInStol;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(playArea, mousePositionInCanvas, eventData.pressEventCamera, out mousePositionInStol);

        Vector2 newPosition = mousePositionInStol;

        // ќграничиваем позицию в пределах PlayArea
        float halfWidth = playArea.rect.width / 2;
        float halfHeight = playArea.rect.height / 2;
        newPosition.x = Mathf.Clamp(newPosition.x, -halfWidth, halfWidth);
        newPosition.y = Mathf.Clamp(newPosition.y, -halfHeight, halfHeight);

        rectTransform.localPosition = newPosition;

        // –ейкастинг дл€ определени€ карты, над которой находитс€ текуща€ карта
        RaycastForCards(eventData);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        // ≈сли карта отпускаетс€ над другой картой
        if (overCard != null)
        {
            overCard.OnCardDrop(transform);
            overCard.OnCardOut(transform);
            overCard = null;
        }

        transform.SetParent(startParent);

        if (startParent == myCards && myCards.childCount > 3)
        {
            // ≈сли мы превысили лимит, возвращаем карту обратно в руку
            transform.SetParent(hand);
        }

        transform.SetSiblingIndex(startParent.childCount); // ќбновл€ем пор€док карты на самый последний
        rectTransform.position = startPosition;
    }

    private void RaycastForCards(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        ICardHandler newOverCard = null;
        foreach (var result in results)
        {
            newOverCard = result.gameObject.GetComponent<ICardHandler>();
            if (newOverCard != null)
            {
                break;
            }
        }
        if (newOverCard != overCard)
        {
            if (overCard != null)
            {
                overCard.OnCardOut(transform);
            }
            overCard = newOverCard;
            if (overCard != null)
            {
                overCard.OnCardOver(transform);
            }
        }
    }
}