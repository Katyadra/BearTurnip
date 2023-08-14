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

    public void HideCardInfo(Card card)
    {
        SelfCard = card;
        Logo.sprite = Resources.Load<Sprite>("Images/CardBack");
        Name.enabled = false;
        CountryLogo.enabled = false;
    }
    public void ShowCardInfo(Card card)
    {
        SelfCard = card;

        Logo.sprite = card.Logo;
        CountryLogo.sprite = card.CountryLogo;
        CountryLogo.preserveAspect = true;
        Name.text = card.Name;
    }
}
