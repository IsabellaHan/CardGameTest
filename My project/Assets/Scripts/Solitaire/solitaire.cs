using System;
using System.Collections.Generic;
using UnityEngine;

public class solitaire : MonoBehaviour
{
 
    public Sprite[] cardSprites;
    public GameObject cardObj;

    public List<CardType> deck;
    // Start is called before the first frame update
    void Start()
    {
        deck = GenerateDeck();
        ShuffleDeck(deck);
       
    }




    List<CardType> newDeck = new List<CardType>();
    private List<CardType> GenerateDeck()
    {


        for (int i = 0; i < 52; i++)
        {
            // Math.Floor() function returns the largest integer less than or equal to a given number.
            CardType.Suites suite = (CardType.Suites)(Math.Floor((decimal)i / 13));
            //Add 2 to value as a cards start a 2
            int val = i % 13 + 2;
            newDeck.Add(new CardType(val, suite));
        }
        return newDeck;

    }

    void ShuffleDeck<CardType>(List<CardType> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            CardType temp = list[i];
            int randomIndex =UnityEngine.Random.Range(i, list.Count);
            // in the i'th position in list, place the random thing in range of list.count
            list[i] = list[randomIndex]; // the i'th thing in the list is placed in a random place in list
            list[randomIndex] = temp;
        }
    }

    public void ShuffleButton() {
        ShuffleDeck(deck);
        foreach (CardType c in deck)
        {
            Debug.Log(c.Name);
        }
    }

    public void DealCards() {
        foreach (CardType c in deck) {
            GameObject newCard = Instantiate(cardObj, transform.position, Quaternion.identity);
            newCard.name = c.Name;
        }
    }
}
