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
        // ��������/��������� ���������, ����� ���������� ������������ ��� �����
        handLayout.enabled = false;
    }

    public void OnCardOut(Transform card)
    {
        // �������� ��������� �������
        handLayout.enabled = true;
    }

    public void OnCardDrop(Transform card)
    {
        // �������� ������� � ��������
        card.SetSiblingIndex(transform.GetSiblingIndex());
    }
}
