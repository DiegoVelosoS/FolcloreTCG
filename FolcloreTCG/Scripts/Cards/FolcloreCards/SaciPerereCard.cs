using UnityEngine;
using System.Collections.Generic;

public class SaciPerereCard : CreatureCard
{
    private void Start()
    {
        cardName = "Saci-Pererê";
        type = CardType.Criatura;
        terrainType = "Floresta";
        power = 3;

        // Adicionar efeitos
        CardEffect returnEffect = new CardEffect
        {
            effectType = CardEffectType.ReturnToHand,
            value = 1,
            description = "Quando esta carta é jogada, você pode escolher uma carta no campo e devolvê-la para a mão do dono.",
            isTargetRequired = true,
            targetType = CardEffectTarget.SpecificCreature,
            isInstant = true,
            isContinuous = false
        };

        CardEffect specialEffect = new CardEffect
        {
            effectType = CardEffectType.Special,
            value = 0,
            description = "Esta carta pode atacar diretamente o jogador oponente se não houver criaturas no campo.",
            isTargetRequired = false,
            isInstant = false,
            isContinuous = true
        };

        AddEffect(returnEffect);
        AddEffect(specialEffect);
    }

    public override void PlayCard()
    {
        base.PlayCard();
        // Tocar som específico do Saci-Pererê
        AudioManager.Instance.Play("SaciLaugh");
    }
} 