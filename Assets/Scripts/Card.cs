using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card : MonoBehaviour
{
    public List<Card> Deck;
    public List<Card> Hand;
    public List<Card> Player1Cards;

    public void DealCards()
    {
        // Перетасовка колоды
        ShuffleDeck();

        // Очистка рук игроков перед раздачей
        Hand.Clear();
        Player1Cards.Clear();

        // Раздача карт между игроками
        int cardsPerPlayer = 3; // Количество карт для каждого игрока

        for (int i = 0; i < cardsPerPlayer; i++)
        {
            // Выбор случайной карты из колоды
            int randomIndex = Random.Range(0, Deck.Count);
            Card card = Deck[randomIndex];

            // Перемещение карты из колоды в руку первого игрока
            Hand.Add(card);
            Deck.RemoveAt(randomIndex);

            // Выбор следующей случайной карты из колоды
            randomIndex = Random.Range(0, Deck.Count);
            card = Deck[randomIndex];

            // Перемещение карты из колоды в руку второго игрока
            Player1Cards.Add(card);
            Deck.RemoveAt(randomIndex);
        }
    }

    private void ShuffleDeck()
    {
        // Алгоритм перетасовки колоды
        for (int i = 0; i < Deck.Count; i++)
        {
            Card temp = Deck[i];
            int randomIndex = Random.Range(i, Deck.Count);
            Deck[i] = Deck[randomIndex];
            Deck[randomIndex] = temp;
        }
    }
}

