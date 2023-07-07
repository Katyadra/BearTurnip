using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragAndDrop;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour, ICardHandler
{
    private HorizontalLayoutGroup handLayout;

    private void Awake()
    {
        handLayout = GetComponentInParent<HorizontalLayoutGroup>();
    }

    public void OnCardOver(Transform card)
    {
        // Включаем/выключаем компонент, чтобы обеспечить пространство для карты
        handLayout.enabled = false;
    }

    public void OnCardOut(Transform card)
    {
        // Включаем компонент обратно
        handLayout.enabled = true;
    }

    public void OnCardDrop(Transform card)
    {
        // Изменяем порядок в иерархии
        card.SetSiblingIndex(transform.GetSiblingIndex());
    }
}
