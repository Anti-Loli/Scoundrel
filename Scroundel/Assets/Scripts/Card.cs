using UnityEngine;

public enum CardSuite
{
    Hearts,
    Diamonds,
    Clubs,
    Spades
}

[CreateAssetMenu(fileName = "Card", menuName = "Cards/New Card")]
public class Card : ScriptableObject
{
    public int value;
    public CardSuite suite;
    public Sprite cardArt;
}
