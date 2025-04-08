using UnityEngine;

[System.Serializable]
public class CardEffect
{
    public CardEffectType effectType;
    public int value;
    public string description;
    public bool isTargetRequired;
    public CardEffectTarget targetType;
    public bool isInstant;
    public bool isContinuous;
    public float duration;
}

public enum CardEffectType
{
    Damage,
    Heal,
    Buff,
    Debuff,
    Destroy,
    ReturnToHand,
    Draw,
    Special
}

public enum CardEffectTarget
{
    Self,
    Opponent,
    AllCreatures,
    RandomCreature,
    SpecificCreature,
    Terrain,
    Hand,
    Deck
} 