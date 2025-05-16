using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CardInstance : MonoBehaviour
{
    public Card template; 

    public void Init (Card data)
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
}
