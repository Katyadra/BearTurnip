using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game
{
    public List<Card> EnemyDeck, PlayerDeck,
                      EnemyHand, PlayerHand,
                      EnemyField, PlayerField;

    public Game()
    {
        EnemyDeck = GiveDeckCard();
        PlayerDeck = GiveDeckCard();

        EnemyHand = new List<Card>(); 
        PlayerHand = new List<Card>();

        EnemyField = new List<Card>();
        PlayerField = new List<Card>();
    }

    List<Card> GiveDeckCard()
    {
        List<Card> randomCards = new List<Card>();
        List<Card> availableCards = new List<Card>(CardManager.AllCards); // Create a copy of the available cards


        for (int i = 0; i < 36; i++)
        {
            if (availableCards.Count > 0)
            {
                int index = UnityEngine.Random.Range(0, availableCards.Count); // Select a random index
                randomCards.Add(availableCards[index]); // Add the card at the selected index to the randomCards list
                availableCards.RemoveAt(index); // Remove the selected card from the available cards list
            }
        }

        return randomCards;
    }
}


public class GameManagerScr : MonoBehaviour
{
    public Game CurrentGame;
    public Transform EnemyHand, PlayerHand;
    public GameObject CardPref;
    public GameObject Deck;
    public TextMeshProUGUI TurnTimeText;
    public Button EndTurnButton;

    void Start()
    {
        CurrentGame = new Game();
        StartCoroutine(GiveInitialHand());
    }

    IEnumerator GiveInitialHand()
    {
        yield return GiveHandCardsCoroutine(CurrentGame.EnemyDeck, EnemyHand, 4, 0.5f, true);
        yield return GiveHandCardsCoroutine(CurrentGame.PlayerDeck, PlayerHand, 4, 0.5f, false);
    }

    IEnumerator GiveHandCardsCoroutine(List<Card> deck, Transform hand, int cardsToGive, float delayInSeconds, bool isEnemy)
    {
        for (int i = 0; i < cardsToGive; i++)
        {
            if (deck.Count == 0)
                break;

            Card card = deck[0];
            yield return GiveCardToHandCoroutine(card, hand, delayInSeconds, isEnemy);

            // ”дал€ем только если это игрок, так как карты противника уже скрыты
            if (!isEnemy)
            {
                deck.RemoveAt(0);
            }
        }
    }

    IEnumerator GiveCardToHandCoroutine(Card card, Transform hand, float delayInSeconds, bool isEnemy)
    {
        yield return new WaitForSeconds(delayInSeconds);

        GameObject cardGO = Instantiate(CardPref, hand, false);
        if (isEnemy)
        {
            cardGO.GetComponent<CardInfoScr>().HideCardInfo(card);
        }
        else
        {
            cardGO.GetComponent<CardInfoScr>().ShowCardInfo(card);
        }

        // ”меньшаем количество карт в колоде
        if (!isEnemy)
        {
            CurrentGame.PlayerDeck.RemoveAt(0);
        }
        else
        {
            CurrentGame.EnemyDeck.RemoveAt(0);
        }
    }
}
