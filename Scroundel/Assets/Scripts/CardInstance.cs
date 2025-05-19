using System;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.Events;

public class CardInstance : MonoBehaviour
{
    public Card template;

    public event Action<CardInstance> PlayCard;

    public void Init(Card data)
    {
        template = data;
        GetComponent<SpriteRenderer>().sprite = data.cardArt;
    }

    public CardSuite GetCardSuite()
    {
        return template.suite;
    }

    public int GetCardValue()
    {
        return template.value;
    }

    void OnMouseDown()
    {
        PlayCard.Invoke(this);
        Destroy(gameObject);
    }
}
