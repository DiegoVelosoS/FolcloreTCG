using UnityEngine;

public class BenzedeiraCard : SupportCard
{
    private void Start()
    {
        cardName = "Benzedeira";
        type = CardType.Suporte;
        terrainType = "Vila";
        effect = "Escolha uma criatura no campo e cure 2 pontos de dano dela.";
        isContinuous = false;
    }

    public override void ActivateEffect()
    {
        base.ActivateEffect();
        // Implementar efeito de cura
    }
} 