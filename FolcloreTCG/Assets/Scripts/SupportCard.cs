using UnityEngine;

public class SupportCard : Card
{
    private void Start()
    {
        cardType = CardType.Support;
    }

    public override void PlayCard()
    {
        base.PlayCard();
        // Specific support card play logic
        Debug.Log($"Playing support card: {cardName}");
    }

    public override void ActivateEffect()
    {
        base.ActivateEffect();
        // Specific support card effect logic
        Debug.Log($"Activating support effect: {effect}");
    }

    public void ApplyEffect(Card target)
    {
        if (target != null)
        {
            // Apply support effect to target card
            Debug.Log($"Applying support effect from {cardName} to {target.cardName}");
        }
    }
} 