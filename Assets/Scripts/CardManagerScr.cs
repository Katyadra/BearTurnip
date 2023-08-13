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
        string[] cardNames = new string[] { "Babka", "Ded", "Dog", "Kot", "Mouse", "Vnuchka" };
        string[] flagNames = new string[] { "Russia", "France", "Italy", "Germany", "UK", "USA" };

        foreach (string cardName in cardNames)
        {
            foreach (string flagName in flagNames)
            {
                string cardPath = $"Images/Cards/{cardName}";
                string flagPath = $"Images/Flags/{flagName}";

                CardManager.AllCards.Add(new Card(cardName, cardPath, flagPath));
            }
        }
    }

}
