using System;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    private bool skippedRoom; //bool check if player skipped previous room
    private bool usedPotion; //bool to check if player used a health potion in the current room
    private bool usedWeapon; //bool to check if player used thier weapon in current room
    private int usedWeaponValue; //int value to track value of first monster player fought

    private  List<CardInstance> roomList = new List<CardInstance>(); //card list for current room
    private  List<Card> discardPile = new List<Card>();//card list for the discard pile
    private  List<Card> slayedMonsters = new List<Card>();//card list for monsters slayed using current weapon

    private CardInstance currentWeapon;//card object for the players current weapon


}
