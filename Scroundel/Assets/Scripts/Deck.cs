using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Deck : MonoBehaviour
{
    private List<Card> cardList = new List<Card>();
    private Queue<Card> deckQueue; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        LoadCards();
        List<Card> shuffled = cardList.OrderBy(c => Random.value).ToList(); 
        deckQueue = new Queue<Card>(shuffled);
    }

    void Start()
    {
        PrintDeck();
    }

    void LoadCards()
    {
        cardList = Resources.LoadAll<Card>("StandardDeck").ToList();
    }

    public Card DrawCard()
    {
        return deckQueue.Dequeue();
    }
    
    public void SendToBottom(Card card)
    {
        deckQueue.Enqueue(card); 
    }

    public void SendRoomToBottom(List<Card> room)
    {
        foreach(Card card in room)
        {
            deckQueue.Enqueue(card);
        }
    }

    public void PrintDeck()
{
    Debug.Log("Deck Contents:");
    foreach (var card in deckQueue)
    {
        Debug.Log($"{card.name} - {card.suite} {card.value}");
    }
}
}
