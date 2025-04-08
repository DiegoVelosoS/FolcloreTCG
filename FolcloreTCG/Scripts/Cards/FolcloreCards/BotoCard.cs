using UnityEngine;

public class BotoCard : CreatureCard
{
    private void Start()
    {
        cardName = "Boto";
        type = CardType.Criatura;
        terrainType = "Rio";
        power = 4;
        effect = "Quando esta carta ataca, você pode devolver uma carta de criatura do campo para a mão do dono.";
    }

    public override void Attack(Card target)
    {
        base.Attack(target);
        // Implementar efeito de devolver criatura para a mão
    }
} 