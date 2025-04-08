using UnityEngine;
using System.Collections.Generic;

public class IaraCard : CreatureCard
{
    private void Start()
    {
        cardName = "Iara";
        type = CardType.Criatura;
        terrainType = "Rio";
        power = 4;

        // Adicionar efeitos
        CardEffect charmEffect = new CardEffect
        {
            effectType = CardEffectType.Special,
            value = 0,
            description = "Quando esta carta ataca, você pode escolher uma criatura do oponente e controlá-la até o final do turno.",
            isTargetRequired = true,
            targetType = CardEffectTarget.SpecificCreature,
            isInstant = false,
            isContinuous = false
        };

        CardEffect healEffect = new CardEffect
        {
            effectType = CardEffectType.Heal,
            value = 1,
            description = "No início do seu turno, cure 1 ponto de vida do jogador.",
            isTargetRequired = false,
            isInstant = true,
            isContinuous = false
        };

        AddEffect(charmEffect);
        AddEffect(healEffect);
    }

    public override void Attack(Card target)
    {
        base.Attack(target);
        // Tocar som específico da Iara
        AudioManager.Instance.Play("IaraSong");
    }
} 