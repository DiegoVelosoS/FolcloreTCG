using UnityEngine;
using System.Collections.Generic;

public enum CardType
{
    Terrain,
    Creature,
    Support
}

public class Card : MonoBehaviour
{
    public string cardName;
    public CardType cardType;
    public string terrainType;
    public string effect;
    public int power;
    public Sprite cardImage;
    
    protected bool isOnField = false;
    protected bool isFaceUp = false;
    
    public virtual void PlayCard()
    {
        // Base implementation for playing a card
        Debug.Log($"Playing card: {cardName}");
    }
    
    public virtual void ActivateEffect()
    {
        // Base implementation for card effects
        Debug.Log($"Activating effect for card: {cardName}");
    }
    
    public void FlipCard()
    {
        isFaceUp = !isFaceUp;
        // Add visual feedback for card flip
    }
    
    public bool IsOnField()
    {
        return isOnField;
    }
    
    public void SetOnField(bool value)
    {
        isOnField = value;
    }
} 