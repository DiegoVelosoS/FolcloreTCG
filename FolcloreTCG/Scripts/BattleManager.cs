using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

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

    public void CalculateBattle(Card attacker, Card defender)
    {
        if (attacker.type != CardType.Criatura)
        {
            Debug.Log("Apenas criaturas podem atacar!");
            return;
        }

        int damage = attacker.power;
        
        if (defender != null)
        {
            // Batalha entre criaturas
            damage = attacker.power - defender.power;
            
            // Tocar som de ataque
            AudioManager.Instance.PlayAttackSound();
            
            // Iniciar animação de ataque
            attacker.GetComponent<CardUI>().PlayAttackAnimation(defender.transform);

            if (damage > 0)
            {
                // Criatura defensora é destruída
                defender.GetComponent<CardUI>().PlayDestroyAnimation();
                StartCoroutine(AnimationManager.Instance.ShakeCamera(0.2f, 0.1f));
            }
            else if (damage < 0)
            {
                // Criatura atacante é destruída
                attacker.GetComponent<CardUI>().PlayDestroyAnimation();
                StartCoroutine(AnimationManager.Instance.ShakeCamera(0.2f, 0.1f));
                damage = 0;
            }
            else
            {
                // Empate - ambas as criaturas são destruídas
                attacker.GetComponent<CardUI>().PlayDestroyAnimation();
                defender.GetComponent<CardUI>().PlayDestroyAnimation();
                StartCoroutine(AnimationManager.Instance.ShakeCamera(0.3f, 0.15f));
                damage = 0;
            }
        }
        else
        {
            // Ataque direto ao jogador
            AudioManager.Instance.Play("DirectAttack");
            StartCoroutine(AnimationManager.Instance.ShakeCamera(0.3f, 0.2f));
        }

        // Aplicar dano ao jogador
        if (damage > 0)
        {
            ApplyDamage(damage);
        }
    }

    private void ApplyDamage(int damage)
    {
        // Implementar lógica de dano ao jogador
        // Atualizar pontos de vida
        // Verificar condição de derrota
    }
} 