using System;
using System.Collections.Generic;
using UnityEngine;
using static CardInstance;

public class Room : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] List<Vector2> spawnPoints = new List<Vector2>();
    [SerializeField] private GameObject cardPrefab;

    private List<Card> cardList = new List<Card>(); //card data of the current room
    private List<CardInstance> roomList = new List<CardInstance>(); //card list for current room

    void Awake()
    {
        if (deck == null)
        {
            Debug.Log("Deck component not found after Inspector assignment");
            deck = GameObject.Find("Deck").GetComponent<Deck>();

            if (deck == null)
            {
                Debug.Log("Deck component not found after Getcomponent");
            }
        }
    }

    void Start()
    {
        deck.FillRoom(cardList);
        SpawnRoom();
    }

    void Update()
    {

    }

    void SpawnRoom()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            Vector2 spawnPos = (i < spawnPoints.Count) ? spawnPoints[i] : Vector2.zero;

            GameObject card = Instantiate(cardPrefab, spawnPos, Quaternion.identity);

            CardInstance cardInstance = card.GetComponent<CardInstance>();

            cardInstance.Init(cardList[i]);

            cardInstance.PlayCard += DiscardCard;

            roomList.Add(cardInstance);
        }
    }


    public void DiscardCard(CardInstance card)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            if (card == roomList[i])
            {
                roomList.RemoveAt(i);
                cardList.RemoveAt(i);
            }
        }

        //  for (int i = 0; i < roomList.Count; i++)
        // {
        //     Debug.Log("Roomlist card " + i + ": " + roomList[i].GetCardSuite() + " " + roomList[i].GetCardValue());
        //     Debug.Log("Cardlist card " + i + ": " + cardList[i].suite + " " + cardList[i].value);
        // }
    }

    public void SkipRoom()
    {
        deck.SendRoomToBottom(cardList);

        // for (int i = 0; i < cardList.Count; i++)
        // {
        //     Debug.Log("Cardlist card " + i + ": " + cardList[i].suite + " " + cardList[i].value);
        // }

        int cardListCurrentInt = cardList.Count;

        for (int i = 0; i < cardListCurrentInt; i++)
        {
            roomList.RemoveAt(0);
            cardList.RemoveAt(0);
        }

        
        // Debug.Log("After removeal: ");

        // for (int i = 0; i < cardList.Count; i++)
        // {
        //     Debug.Log("Cardlist card " + i + ": " + cardList[i].suite + " " + cardList[i].value);
        // }
        
        deck.FillRoom(cardList);

        GameObject[] sceneInstaces = GameObject.FindGameObjectsWithTag("CardInstance");

        for (int i = 0; i < sceneInstaces.Length; i++)
        {
            Destroy(sceneInstaces[i]);
        }        

        SpawnRoom();
    }

}