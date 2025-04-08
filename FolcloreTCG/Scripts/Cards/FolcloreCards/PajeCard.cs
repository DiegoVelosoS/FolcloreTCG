using UnityEngine;

public class PajeCard : SupportCard
{
    private void Start()
    {
        cardName = "Pajé";
        type = CardType.Suporte;
        terrainType = "Aldeia";
        effect = "Escolha uma criatura no campo. Ela ganha +2 de poder até o final do turno.";
        isContinuous = false;
    }

    public override void ActivateEffect()
    {
        base.ActivateEffect();
        // Implementar efeito de aumentar poder temporariamente
    }
} 