using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeckView : MonoBehaviour
{
    public Transform deckPosition; // Reference to the transform representing the deck's position
    public float cardOffset;
    public GameObject cardPrefab;
    public TextMeshProUGUI cardCountText;

    private List<GameObject> cardInstances = new List<GameObject>();

    private void Start()
    {
        // Instantiate cards from the AllCards list
        foreach (Card cardData in CardManager.AllCards)
        {
            GameObject cardInstance = Instantiate(cardPrefab, transform);
            Vector3 cardPosition = deckPosition.position + cardInstances.Count * cardOffset * -deckPosition.up;
            cardInstance.transform.position = cardPosition;
            cardInstances.Add(cardInstance);
        }

        UpdateCardCountText(cardInstances.Count);
    }

    private void UpdateCardCountText(int cardCount)
    {
        if (cardCountText != null)
        {
            cardCountText.text = $"Card Count: {cardCount}";
        }
    }

    // You can call this method when you want to add a card to the deck
    public void AddCardToDeck()
    {
        GameObject cardInstance = Instantiate(cardPrefab, transform);
        Vector3 cardPosition = deckPosition.position + cardInstances.Count * cardOffset * -deckPosition.up;
        cardInstance.transform.position = cardPosition;
        cardInstances.Add(cardInstance);
        UpdateCardCountText(cardInstances.Count);
    }

    // You can call this method when you want to remove a card from the deck
    public void RemoveCardFromDeck()
    {
        if (cardInstances.Count > 0)
        {
            GameObject lastCard = cardInstances[cardInstances.Count - 1];
            cardInstances.Remove(lastCard);
            Destroy(lastCard);

            UpdateCardCountText(cardInstances.Count);
        }
    }
}
