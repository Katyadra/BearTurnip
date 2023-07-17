using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Card
{
    public string Name;
    public Sprite Logo;
    public Sprite CountryLogo;

    public Card(string name, string logoPath, string countrylogoPath)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        CountryLogo = Resources.Load<Sprite>(countrylogoPath);
    }
}
public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
}

public class CardManagerScr : MonoBehaviour
{
    public void Awake()
    {
        // Load all card images
        var cardImages = Resources.LoadAll<Sprite>("Images/Cards");

        // Load all country flag images
        var countryFlags = Resources.LoadAll<Sprite>("Images/Flags");

        foreach (var cardImage in cardImages)
        {
            foreach (var countryFlag in countryFlags)
            {
                // Create a new card with the name of the cardImage, cardImage path, and each countryFlag path
                var newCard = new Card(cardImage.name, $"Images/Cards/{cardImage.name}", $"Images/Flags/{countryFlag.name}");

                // Add the new card to the AllCards list
                CardManager.AllCards.Add(newCard);

                // Log the paths
                Debug.Log($"Card Image Path: Images/Cards/{cardImage.name}");
                Debug.Log($"Country Flag Path: Images/Flags/{countryFlag.name}");
            }
        }
    }

}

