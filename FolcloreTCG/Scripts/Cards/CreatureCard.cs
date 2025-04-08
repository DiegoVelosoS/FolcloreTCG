using UnityEngine;

public class CreatureCard : Card
{
    public bool canAttack = true;
    public bool isDefending = false;

    public override void PlayCard()
    {
        base.PlayCard();
        // Lógica específica para cartas de criatura
    }

    public override void ActivateEffect()
    {
        base.ActivateEffect();
        // Efeito específico da criatura
    }

    public void Attack(Card target)
    {
        if (canAttack && GameManager.Instance.currentPhase == GameManager.GamePhase.Battle)
        {
            BattleManager.Instance.CalculateBattle(this, target as CreatureCard);
            canAttack = false;
        }
    }

    public void Defend()
    {
        isDefending = true;
    }
} 