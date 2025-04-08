using UnityEngine;
using System.Collections.Generic;

public enum CardType
{
    Terreno,
    Criatura,
    Suporte
}

public class Card : MonoBehaviour
{
    public string cardName;
    public CardType type;
    public string terrainType;
    public List<CardEffect> effects = new List<CardEffect>();
    public int power;
    public Sprite cardImage;

    protected virtual void Start()
    {
        // Inicialização básica da carta
    }

    public virtual void PlayCard()
    {
        // Lógica base para jogar a carta
        foreach (CardEffect effect in effects)
        {
            if (effect.isInstant)
            {
                CardEffectManager.Instance.ApplyEffect(this, effect);
            }
        }
    }

    public virtual void ActivateEffect()
    {
        // Lógica base para ativar o efeito da carta
        foreach (CardEffect effect in effects)
        {
            if (!effect.isInstant)
            {
                CardEffectManager.Instance.ApplyEffect(this, effect);
            }
        }
    }

    public void AddEffect(CardEffect effect)
    {
        effects.Add(effect);
    }

    public void RemoveEffect(CardEffect effect)
    {
        effects.Remove(effect);
    }

    public string GetEffectDescription()
    {
        string description = "";
        foreach (CardEffect effect in effects)
        {
            description += effect.description + "\n";
        }
        return description.Trim();
    }
} 