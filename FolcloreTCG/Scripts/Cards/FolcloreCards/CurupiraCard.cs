using UnityEngine;

public class CurupiraCard : CreatureCard
{
    private void Start()
    {
        cardName = "Curupira";
        type = CardType.Criatura;
        terrainType = "Floresta";
        power = 4;
        effect = "Quando esta carta ataca, você pode escolher um terreno no campo e destruí-lo.";
    }

    public override void Attack(Card target)
    {
        base.Attack(target);
        // Implementar efeito de destruir terreno
    }
} 