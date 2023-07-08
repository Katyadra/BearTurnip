using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string name;
    public string country;
    public bool isSpecial;

    public Card(string name, string country, bool isSpecial)
    {
        this.name = name;
        this.country = country;
        this.isSpecial = isSpecial;
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
        CardManager.AllCards.Add(new Card("Babka", "Russia", false));
        CardManager.AllCards.Add(new Card("Ded", "Russia", false));
        CardManager.AllCards.Add(new Card("Vnuchka", "Russia", false));
        CardManager.AllCards.Add(new Card("Dog", "Russia", false));
        CardManager.AllCards.Add(new Card("Cat", "Russia", false));
        CardManager.AllCards.Add(new Card("Mouse", "Russia", false));
        CardManager.AllCards.Add(new Card("Babka", "Usa", false));
        CardManager.AllCards.Add(new Card("Ded", "Usa", false));
        CardManager.AllCards.Add(new Card("Vnuchka", "Usa", false));
        CardManager.AllCards.Add(new Card("Dog", "Usa", false));
        CardManager.AllCards.Add(new Card("Cat", "Usa", false));
        CardManager.AllCards.Add(new Card("Mouse", "Usa", false));
        CardManager.AllCards.Add(new Card("Babka", "England", false));
        CardManager.AllCards.Add(new Card("Ded", "England", false));
        CardManager.AllCards.Add(new Card("Vnuchka", "England", false));
        CardManager.AllCards.Add(new Card("Dog", "England", false));
        CardManager.AllCards.Add(new Card("Cat", "England", false));
        CardManager.AllCards.Add(new Card("Mouse", "England", false));
        CardManager.AllCards.Add(new Card("Babka", "Italy", false));
        CardManager.AllCards.Add(new Card("Ded", "Italy", false));
        CardManager.AllCards.Add(new Card("Vnuchka", "Italy", false));
        CardManager.AllCards.Add(new Card("Dog", "Italy", false));
        CardManager.AllCards.Add(new Card("Cat", "Italy", false));
        CardManager.AllCards.Add(new Card("Mouse", "Italy", false));
    }
}