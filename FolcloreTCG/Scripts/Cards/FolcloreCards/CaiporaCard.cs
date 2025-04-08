using UnityEngine;
using System.Collections.Generic;

public class CaiporaCard : CreatureCard
{
    private void Start()
    {
        cardName = "Caipora";
        type = CardType.Criatura;
        terrainType = "Floresta";
        power = 5;

        // Adicionar efeitos
        CardEffect protectEffect = new CardEffect
        {
            effectType = CardEffectType.Special,
            value = 0,
            description = "Todas as outras criaturas do tipo Floresta ganham +1 de poder enquanto esta carta estiver no campo.",
            isTargetRequired = false,
            isInstant = false,
            isContinuous = true
        };

        CardEffect summonEffect = new CardEffect
        {
            effectType = CardEffectType.Special,
            value = 0,
            description = "Quando esta carta é jogada, você pode colocar uma carta de terreno Floresta do seu deck no campo.",
            isTargetRequired = false,
            isInstant = true,
            isContinuous = false
        };

        AddEffect(protectEffect);
        AddEffect(summonEffect);
    }

    public override void PlayCard()
    {
        base.PlayCard();
        // Tocar som específico do Caipora
        AudioManager.Instance.Play("CaiporaWhistle");
    }
} 