using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private GameLogic gameLogic;

    void Start()
    {
        gameLogic = new GameLogic();
        gameLogic.Initialize();
        gameLogic.DealCards();
    }

    void Update()
    {
        // Ваш код обновления
    }
}

public class GameLogic
{
    private Deck deck;
    private List<CardData> playersHand;
    private List<CardData> tableCards;
    private int actionPoints;

    public GameLogic()
    {
        deck = new Deck();
        playersHand = new List<CardData>();
        tableCards = new List<CardData>();
        actionPoints = 3;
    }

    public void Initialize()
    {
        // Создание карт и добавление их в колоду
        // Страны: 6 по 6 карт
        // Особые действия: 8 карт

        // Пример создания карт стран
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                string countryName = GetCountryName(i);
                CardData countryCard = new CardData(countryName, i + 1, i + 1);
                deck.AddCard(countryCard);
            }
        }

        // Пример создания карт особых действий
        for (int i = 0; i < 8; i++)
        {
            string specialActionName = GetSpecialActionName(i);
            CardData specialActionCard = new CardData(specialActionName, 0, 0);
            deck.AddCard(specialActionCard);
        }

        // Тасование колоды
        deck.Shuffle();
    }

    private string GetCountryName(int index)
    {
        string[] countryNames = { "Country A", "Country B", "Country C", "Country D", "Country E", "Country F" };
        return countryNames[index];
    }

    private string GetSpecialActionName(int index)
    {
        string[] specialActionNames = { "Special Action 1", "Special Action 2", "Special Action 3", "Special Action 4", "Special Action 5", "Special Action 6", "Special Action 7", "Special Action 8" };
        return specialActionNames[index];
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

    public void PlayCard(CardData card)
    {
        // Реализуйте логику для выполнения действий, связанных с выбранной картой
        // Например, обмен картами, применение особого действия и т.д.
    }

    public void ExchangeCards(CardData playerCard, CardData otherPlayerCard)
    {
        // Реализуйте логику обмена картами между игроком и другим игроком
    }

    public void TakeExtraCard()
    {
        // Реализуйте логику взятия дополнительной карты из колоды
    }

    public void DiscardCards()
    {
        // Реализуйте логику сброса использованных или ненужных карт в "биту"
    }

    public bool CheckWinCondition()
    {
        // Реализуйте логику проверки условий победы
        // Например, если игрок собрал 6 карт одной страны
        return false;
    }
}

public class Deck
{
    private List<CardData> cards;
    private System.Random rng;

    public Deck()
    {
        cards = new List<CardData>();
        rng = new System.Random();
    }

    public void AddCard(CardData card)
    {
        cards.Add(card);
    }

    public void Shuffle()
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            CardData value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    public CardData DrawCard()
    {
        if (cards.Count == 0)
        {
            Debug.Log("No cards left in the deck!");
            return null;
        }

        CardData drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }
}

public class CardData
{
    public string name;
    public int power;
    public int health;

    public CardData(string name, int power, int health)
    {
        this.name = name;
        this.power = power;
        this.health = health;
    }
}
