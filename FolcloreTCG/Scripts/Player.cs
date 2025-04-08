using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public string playerName;
    public int lifePoints;
    public DeckManager deckManager;
    public bool isActivePlayer;

    private void Start()
    {
        lifePoints = GameManager.Instance.maxLifePoints;
        deckManager = GetComponent<DeckManager>();
    }

    public void InitializePlayer(string name, List<Card> deck)
    {
        playerName = name;
        deckManager.InitializeDeck(deck);
        DrawInitialHand();
    }

    private void DrawInitialHand()
    {
        deckManager.DrawCard(GameManager.Instance.initialHandSize);
    }

    public void TakeDamage(int damage)
    {
        lifePoints -= damage;
        if (lifePoints <= 0)
        {
            GameManager.Instance.CheckGameEnd();
        }
    }

    public void PlayCard(Card card, CardZone zone)
    {
        if (isActivePlayer && GameManager.Instance.currentPhase == GameManager.GamePhase.Preparation)
        {
            deckManager.PlayCard(card, zone);
        }
    }

    public void EndTurn()
    {
        if (isActivePlayer)
        {
            GameManager.Instance.EndTurn();
        }
    }
} 