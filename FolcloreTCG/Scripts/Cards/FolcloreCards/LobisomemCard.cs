using UnityEngine;
using System.Collections.Generic;

public class LobisomemCard : CreatureCard
{
    private bool isTransformed = false;

    private void Start()
    {
        cardName = "Lobisomem";
        type = CardType.Criatura;
        terrainType = "Floresta";
        power = 4;

        // Adicionar efeitos
        CardEffect transformEffect = new CardEffect
        {
            effectType = CardEffectType.Special,
            value = 0,
            description = "Durante a noite (turnos ímpares), esta carta se transforma e ganha +3 de poder.",
            isTargetRequired = false,
            isInstant = false,
            isContinuous = true
        };

        CardEffect healEffect = new CardEffect
        {
            effectType = CardEffectType.Heal,
            value = 2,
            description = "Quando esta carta destrói uma criatura, cura 2 pontos de vida do jogador.",
            isTargetRequired = false,
            isInstant = true,
            isContinuous = false
        };

        AddEffect(transformEffect);
        AddEffect(healEffect);
    }

    public override void PlayCard()
    {
        base.PlayCard();
        CheckTransformation();
    }

    private void CheckTransformation()
    {
        bool isNight = GameManager.Instance.turnCount % 2 == 1;
        if (isNight && !isTransformed)
        {
            power += 3;
            isTransformed = true;
            // Tocar som de transformação
            AudioManager.Instance.Play("WerewolfTransform");
        }
        else if (!isNight && isTransformed)
        {
            power -= 3;
            isTransformed = false;
        }
    }
} 