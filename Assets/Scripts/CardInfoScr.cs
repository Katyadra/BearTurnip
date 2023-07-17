using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfoScr : MonoBehaviour
{
    public Card SelfCard;
    public Image Logo;
    public Image CountryLogo;
    public TextMeshProUGUI Name;

    public void ShowCardInfo(Card card)
    {
        SelfCard = card;

        Logo.sprite = card.Logo;
        Logo.preserveAspect = true; 
        CountryLogo.sprite = card.CountryLogo;
        CountryLogo.preserveAspect = true;  
        Name.text = card.Name;
    }
/*
    private void Start()
    {
        ShowCardInfo(CardManager.AllCards[transform.GetSiblingIndex()]);
    }*/
}
