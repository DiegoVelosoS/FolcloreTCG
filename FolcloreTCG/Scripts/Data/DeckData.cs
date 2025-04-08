using System;
using System.Collections.Generic;

[Serializable]
public class DeckData
{
    public string deckName;
    public List<string> cardNames;

    public DeckData(string name, List<Card> cards)
    {
        deckName = name;
        cardNames = new List<string>();
        foreach (Card card in cards)
        {
            cardNames.Add(card.cardName);
        }
    }
} 