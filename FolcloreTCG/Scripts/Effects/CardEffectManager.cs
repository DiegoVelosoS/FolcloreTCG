using UnityEngine;
using System.Collections.Generic;

public class CardEffectManager : MonoBehaviour
{
    public static CardEffectManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ApplyEffect(Card card, CardEffect effect)
    {
        switch (effect.effectType)
        {
            case CardEffectType.Damage:
                ApplyDamageEffect(card, effect);
                break;
            case CardEffectType.Heal:
                ApplyHealEffect(card, effect);
                break;
            case CardEffectType.Buff:
                ApplyBuffEffect(card, effect);
                break;
            case CardEffectType.Debuff:
                ApplyDebuffEffect(card, effect);
                break;
            case CardEffectType.Destroy:
                ApplyDestroyEffect(card, effect);
                break;
            case CardEffectType.ReturnToHand:
                ApplyReturnToHandEffect(card, effect);
                break;
            case CardEffectType.Draw:
                ApplyDrawEffect(card, effect);
                break;
            case CardEffectType.Special:
                ApplySpecialEffect(card, effect);
                break;
        }
    }

    private void ApplyDamageEffect(Card card, CardEffect effect)
    {
        if (card.type == CardType.Criatura)
        {
            CreatureCard creature = card as CreatureCard;
            creature.power -= effect.value;
            if (creature.power <= 0)
            {
                creature.GetComponent<CardUI>().PlayDestroyAnimation();
            }
        }
        else
        {
            // Aplicar dano ao jogador
            GameManager.Instance.player.TakeDamage(effect.value);
        }
    }

    private void ApplyHealEffect(Card card, CardEffect effect)
    {
        if (card.type == CardType.Criatura)
        {
            CreatureCard creature = card as CreatureCard;
            creature.power += effect.value;
        }
        else
        {
            // Curar jogador
            GameManager.Instance.player.lifePoints = Mathf.Min(
                GameManager.Instance.player.lifePoints + effect.value,
                GameManager.Instance.maxLifePoints
            );
        }
    }

    private void ApplyBuffEffect(Card card, CardEffect effect)
    {
        if (card.type == CardType.Criatura)
        {
            CreatureCard creature = card as CreatureCard;
            creature.power += effect.value;
            // Adicionar efeito visual de buff
            StartCoroutine(AnimationManager.Instance.PlayBuffAnimation(creature.transform));
        }
    }

    private void ApplyDebuffEffect(Card card, CardEffect effect)
    {
        if (card.type == CardType.Criatura)
        {
            CreatureCard creature = card as CreatureCard;
            creature.power -= effect.value;
            // Adicionar efeito visual de debuff
            StartCoroutine(AnimationManager.Instance.PlayDebuffAnimation(creature.transform));
        }
    }

    private void ApplyDestroyEffect(Card card, CardEffect effect)
    {
        card.GetComponent<CardUI>().PlayDestroyAnimation();
    }

    private void ApplyReturnToHandEffect(Card card, CardEffect effect)
    {
        // Implementar lógica para devolver carta para a mão
    }

    private void ApplyDrawEffect(Card card, CardEffect effect)
    {
        // Implementar lógica para comprar cartas
    }

    private void ApplySpecialEffect(Card card, CardEffect effect)
    {
        // Implementar efeitos especiais específicos de cada carta
        switch (card.cardName)
        {
            case "Saci-Pererê":
                // Implementar efeito do Saci-Pererê
                break;
            case "Curupira":
                // Implementar efeito do Curupira
                break;
            case "Boitatá":
                // Implementar efeito do Boitatá
                break;
            case "Boto":
                // Implementar efeito do Boto
                break;
            // Adicionar mais casos conforme necessário
        }
    }
} 