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

        // ������� �� 3 ����� ������� ������
        List<GameObject> player1HandCards = DealCards(3, player1Hand);
        List<GameObject> player2HandCards = DealCards(3, player2Hand);
    }

    void CreateDeck()
    {
        // ��������������, ��� � ��� ���� 6 ��������: cardPrefab1, cardPrefab2, ..., cardPrefab6
        GameObject[] cardPrefabsArray = new GameObject[] { ded, babka, vnuchka, kot, sobaka, mouse };

        for (int i = 0; i < cardPrefabsArray.Length; i++)
        {
            string cardName = $"Country Card {i + 1}";
            cardPrefabs.Add(cardName, cardPrefabsArray[i]);

            // ��������� 6 ����������� ������ ����� � ������
            for (int j = 0; j < 6; j++)
            {
                deck.Add(cardName);
            }
        }

       // ��������� � ������ 8 ���� ������ ��������
       // ��������������, ��� � ��� ���� ������� ��� ������ �� 8 ������ ����
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
            // ����� ������� ����� ������
            string cardName = deck[0];
            // ������� ����� ������ Card �� �����
            GameObject cardObject = Instantiate(cardPrefabs[cardName], handTransform);
            // ��������� ����� � ����
            hand.Add(cardObject);
            // ������� ����� �� ������
            deck.RemoveAt(0);
        }

        return hand;
    }
}
