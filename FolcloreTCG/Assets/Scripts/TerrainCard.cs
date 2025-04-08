using UnityEngine;

public class TerrainCard : Card
{
    private void Start()
    {
        cardType = CardType.Terrain;
    }

    public override void PlayCard()
    {
        base.PlayCard();
        // Specific terrain card play logic
        Debug.Log($"Playing terrain card: {cardName} of type {terrainType}");
    }

    public override void ActivateEffect()
    {
        base.ActivateEffect();
        // Specific terrain card effect logic
        Debug.Log($"Activating terrain effect: {effect}");
    }
} 