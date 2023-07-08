using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Deck deck;
    private List<CardData> playersHand;
    private List<CardData> tableCards;
    private int actionPoints;

    private void Start()
    {
        deck = new Deck();
        playersHand = new List<CardData>();
        tableCards = new List<CardData>();
        actionPoints = 3;
    }

    public void Initialize()
    {
        // �������� ���� � ���������� �� � ������
        // ������: 6 �� 6 ����
        // ������ ��������: 8 ����

        // ��������� ������
        deck.Shuffle();
    }

    public void DealCards()
    {
        for (int i = 0; i < 3; i++)
        {
            playersHand.Add(deck.DrawCard());
        }

        for (int i = 0; i < 4; i++)
        {
            tableCards.Add(deck.DrawCard());
        }
    }

    public void PlayCard(Card card)
    {
        // ���������� ������ ��� ���������� ��������, ��������� � ��������� ������
        // ��������, ����� �������, ���������� ������� �������� � �.�.
    }

    public void ExchangeCards(Card playerCard, Card otherPlayerCard)
    {
        // ���������� ������ ������ ������� ����� ������� � ������ �������
    }

    public void TakeExtraCard()
    {
        // ���������� ������ ������ �������������� ����� �� ������
    }

    public void DiscardCards()
    {
        // ���������� ������ ������ �������������� ��� �������� ���� � "����"
    }

    public bool CheckWinCondition()
    {
        // ���������� ������ �������� ������� ������
        // ��������, ���� ����� ������ 6 ���� ����� ������
        return false;
    }

    private void Update()
    {
        // ��� ��� ����������
    }
}
