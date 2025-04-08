using UnityEngine;

public class BoitataCard : CreatureCard
{
    private void Start()
    {
        cardName = "Boitatá";
        type = CardType.Criatura;
        terrainType = "Floresta";
        power = 5;
        effect = "Quando esta carta é jogada, você pode destruir um terreno no campo. Se fizer isso, esta carta ganha +2 de poder.";
    }

    public override void PlayCard()
    {
        base.PlayCard();
        // Implementar efeito de destruir terreno e ganhar poder
    }
} 