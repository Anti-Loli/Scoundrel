using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class CardInstance : MonoBehaviour
{
    public Card template; 

    public CardInstance (Card data)
    {
        template = data;
    }

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = template.cardArt;   
        Debug.Log("Card Suite: " + template.suite);
        Debug.Log("Card Value: " + template.value);

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
