using System;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] List<Vector2> spawnPoints = new List<Vector2>();
    [SerializeField] private GameObject cardPrefab;

    private  List<Card> cardList = new List<Card>(); //card data of the current room
    private  List<CardInstance> roomList = new List<CardInstance>(); //card list for current room

    void Awake()
    {
        if(deck == null)
        {
            Debug.Log("Deck component not found after Inspector assignment");
            deck = GameObject.Find("Deck").GetComponent<Deck>();

             if(deck == null)
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
        for(int i = 0; i < cardList.Count; i++)
        {
            Vector2 spawnPos = (i < spawnPoints.Count) ? spawnPoints[i] : Vector2.zero;

            GameObject card = Instantiate(cardPrefab, spawnPos, Quaternion.identity);

            CardInstance cardInstance = card.GetComponent<CardInstance>();

            cardInstance.Init(cardList[i]);

            roomList.Add(cardInstance);
        }
    }
}
