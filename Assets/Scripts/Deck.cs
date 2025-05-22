using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Deck : MonoBehaviour
{
    private List<Card> cardList = new List<Card>();
    private Queue<Card> deckQueue; 

    void Awake()
    {
        LoadCards();
        List<Card> shuffled = cardList.OrderBy(c => Random.value).ToList(); 
        deckQueue = new Queue<Card>(shuffled);
    }

    void Start()
    {
       // PrintDeck();
    }

    void LoadCards()
    {
        cardList = Resources.LoadAll<Card>("StandardDeck").ToList();
    }

    public Card DrawCard()
    {
        return deckQueue.Dequeue();
    }

    public List<Card> FillRoom(List<Card> roomList)
    {
        Card deckDequeue; 

        for(int i = 0; i< 4; i++)
        {
            deckDequeue = deckQueue.Dequeue();
            roomList.Add(deckDequeue);
        }

        return roomList;
    }
    
    public List<Card> NextRoom(List<Card> roomList)
    {
        Card deckDequeue; 

        for(int i = 0; i< 3; i++)
        {
            deckDequeue = deckQueue.Dequeue();
            roomList.Add(deckDequeue);
        }

        return roomList;
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
