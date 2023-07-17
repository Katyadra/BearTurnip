using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public Dictionary<string, GameObject> cardPrefabs = new Dictionary<string, GameObject>();
    public Transform player1Hand;
    public Transform player2Hand;
    public GameObject ded;
    public GameObject babka;
    public GameObject vnuchka;
    public GameObject kot;
    public GameObject sobaka;
    public GameObject mouse;

    public GameObject specialCardPrefab1;
    public GameObject specialCardPrefab2;
    public GameObject specialCardPrefab8;


    private List<string> deck = new List<string>();

    void Start()
    {
        CreateDeck();
        ShuffleDeck();

        // Раздаем по 3 карты каждому игроку
        List<GameObject> player1HandCards = DealCards(3, player1Hand);
        List<GameObject> player2HandCards = DealCards(3, player2Hand);
    }

    void CreateDeck()
    {
        // Предполагается, что у вас есть 6 префабов: cardPrefab1, cardPrefab2, ..., cardPrefab6
        GameObject[] cardPrefabsArray = new GameObject[] { ded, babka, vnuchka, kot, sobaka, mouse };

        for (int i = 0; i < cardPrefabsArray.Length; i++)
        {
            string cardName = $"Country Card {i + 1}";
            cardPrefabs.Add(cardName, cardPrefabsArray[i]);

            // Добавляем 6 экземпляров каждой карты в колоду
            for (int j = 0; j < 6; j++)
            {
                deck.Add(cardName);
            }
        }

       // Добавляем в колоду 8 карт особых действий
       // Предполагается, что у вас есть префабы для каждой из 8 особых карт
        GameObject[] specialCardPrefabs = new GameObject[] { specialCardPrefab1, specialCardPrefab2, specialCardPrefab8 };
        for (int i = 0; i < specialCardPrefabs.Length; i++)
        {
            string cardName = $"Special Card {i + 1}";
            cardPrefabs.Add(cardName, specialCardPrefabs[i]);
            deck.Add(cardName);
        }
    }


    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            string temp = deck[i];
            int randomIndex = Random.Range(0, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    List<GameObject> DealCards(int numberOfCards, Transform handTransform)
    {
        List<GameObject> hand = new List<GameObject>();

        for (int i = 0; i < numberOfCards; i++)
        {
            // Берем верхнюю карту колоды
            string cardName = deck[0];
            // Создаем новый объект Card на сцене
            GameObject cardObject = Instantiate(cardPrefabs[cardName], handTransform);
            // Добавляем карту в руку
            hand.Add(cardObject);
            // Удаляем карту из колоды
            deck.RemoveAt(0);
        }

        return hand;
    }
}
