using UnityEngine;

public class CreatureCard : Card
{
    private void Start()
    {
        cardType = CardType.Creature;
    }

    public override void PlayCard()
    {
        base.PlayCard();
        // Specific creature card play logic
        Debug.Log($"Playing creature card: {cardName} with power {power}");
    }

    public override void ActivateEffect()
    {
        base.ActivateEffect();
        // Specific creature card effect logic
        Debug.Log($"Activating creature effect: {effect}");
    }

    public void Attack(CreatureCard target)
    {
        if (target != null)
        {
            // Combat logic between creatures
            Debug.Log($"{cardName} attacking {target.cardName}");
        }
        else
        {
            // Direct attack to player
            Debug.Log($"{cardName} attacking directly");
        }
    }
} 