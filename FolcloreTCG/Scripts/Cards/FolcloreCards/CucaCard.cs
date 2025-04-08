using UnityEngine;
using System.Collections.Generic;

public class CucaCard : CreatureCard
{
    private void Start()
    {
        cardName = "Cuca";
        type = CardType.Criatura;
        terrainType = "Floresta";
        power = 6;

        // Adicionar efeitos
        CardEffect fearEffect = new CardEffect
        {
            effectType = CardEffectType.Special,
            value = 0,
            description = "Quando esta carta é invocada, todas as criaturas do oponente com poder menor que 3 são devolvidas para a mão.",
            isTargetRequired = false,
            isInstant = true,
            isContinuous = false
        };

        CardEffect stealEffect = new CardEffect
        {
            effectType = CardEffectType.Special,
            value = 0,
            description = "Quando esta carta destrói uma criatura, você pode roubar uma carta da mão do oponente.",
            isTargetRequired = false,
            isInstant = true,
            isContinuous = false
        };

        AddEffect(fearEffect);
        AddEffect(stealEffect);
    }

    public override void PlayCard()
    {
        base.PlayCard();
        // Tocar som específico da Cuca
        AudioManager.Instance.Play("CucaLaugh");
    }
} 