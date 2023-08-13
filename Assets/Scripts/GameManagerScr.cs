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
    int Turn, TurnTime = 30;
    public TextMeshProUGUI TurnTimeText;
    public Button EndTurnButton;

    void Start()
    {
        CurrentGame = new Game();

        GiveHandCards(CurrentGame.EnemyDeck, EnemyHand);
        GiveHandCards(CurrentGame.PlayerDeck, PlayerHand);
    }

    void GiveHandCards(List<Card> deck, Transform hand)
    {
        int i = 0;
        while (i++ < 4)
            GiveCardToHand(deck, hand);
    }

    void GiveCardToHand(List<Card> deck, Transform hand)
    {
        if (deck.Count == 0)
            return;

        Card card = deck[0];

        GameObject cardGO = Instantiate(CardPref, hand, false);

        if (hand == EnemyHand)
            cardGO.GetComponent<CardInfoScr>().HideCardInfo(card);
        else
            cardGO.GetComponent<CardInfoScr>().ShowCardInfo(card);

        deck.RemoveAt(0);
    }

}
