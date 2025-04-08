using UnityEngine;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public List<Card> hand = new List<Card>();
    public List<Card> discardPile = new List<Card>();
    public List<Card> terrainZone = new List<Card>();
    public List<Card> field = new List<Card>();

    public void InitializeDeck(List<Card> startingDeck)
    {
        deck = new List<Card>(startingDeck);
        ShuffleDeck();
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void DrawCard(int amount = 1)
    {
        for (int i = 0; i < amount; i++)
        {
            if (deck.Count > 0)
            {
                Card drawnCard = deck[0];
                deck.RemoveAt(0);
                hand.Add(drawnCard);
            }
            else
            {
                // Verificar condição de derrota por não ter cartas para comprar
                GameManager.Instance.CheckGameEnd();
            }
        }
    }

    public void PlayCard(Card card, CardZone zone)
    {
        if (hand.Contains(card))
        {
            hand.Remove(card);
            switch (zone)
            {
                case CardZone.Terrain:
                    if (terrainZone.Count < GameManager.Instance.maxTerrainCards)
                    {
                        terrainZone.Add(card);
                    }
                    break;
                case CardZone.Field:
                    field.Add(card);
                    break;
            }
        }
    }

    public void DiscardCard(Card card)
    {
        if (hand.Contains(card))
        {
            hand.Remove(card);
            discardPile.Add(card);
        }
    }
}

public enum CardZone
{
    Hand,
    Terrain,
    Field,
    Discard
} 