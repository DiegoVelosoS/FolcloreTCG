using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public string playerName;
    public int lifePoints;
    public List<Card> deck;
    public List<Card> hand;
    public List<Card> field;
    public List<Card> graveyard;

    public void Initialize(int startingLifePoints)
    {
        lifePoints = startingLifePoints;
        hand = new List<Card>();
        field = new List<Card>();
        graveyard = new List<Card>();
    }

    public void DrawCard()
    {
        if (deck.Count > 0)
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);
            hand.Add(drawnCard);
            Debug.Log($"{playerName} drew a card: {drawnCard.cardName}");
        }
        else
        {
            Debug.Log($"{playerName} has no cards left to draw!");
            GameManager.Instance.CheckGameEnd();
        }
    }

    public void PlayCard(Card card)
    {
        if (GameManager.Instance.CanPlayCard(card))
        {
            hand.Remove(card);
            field.Add(card);
            card.SetOnField(true);
            card.PlayCard();
            Debug.Log($"{playerName} played {card.cardName}");
        }
    }

    public void TakeDamage(int damage)
    {
        lifePoints -= damage;
        Debug.Log($"{playerName} took {damage} damage. Remaining life points: {lifePoints}");
        GameManager.Instance.CheckGameEnd();
    }

    public int GetTerrainCount()
    {
        int count = 0;
        foreach (Card card in field)
        {
            if (card.cardType == CardType.Terrain)
            {
                count++;
            }
        }
        return count;
    }

    public void DiscardCard(Card card)
    {
        if (hand.Contains(card))
        {
            hand.Remove(card);
            graveyard.Add(card);
            Debug.Log($"{playerName} discarded {card.cardName}");
        }
    }
} 