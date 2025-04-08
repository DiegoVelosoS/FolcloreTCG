using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int maxLifePoints = 10;
    public int minDeckSize = 20;
    public int maxDeckSize = 40;
    public int startingHandSize = 5;
    public int maxTerrainCards = 4;

    private Player currentPlayer;
    private Player opponentPlayer;
    private bool isGameStarted = false;
    private GamePhase currentPhase;

    public enum GamePhase
    {
        Draw,
        Main,
        Battle,
        End
    }

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

    public void StartGame(Player player1, Player player2)
    {
        currentPlayer = player1;
        opponentPlayer = player2;
        isGameStarted = true;
        currentPhase = GamePhase.Draw;

        // Initialize players
        player1.Initialize(maxLifePoints);
        player2.Initialize(maxLifePoints);

        // Draw starting hands
        for (int i = 0; i < startingHandSize; i++)
        {
            player1.DrawCard();
            player2.DrawCard();
        }

        Debug.Log("Game started!");
    }

    public void EndTurn()
    {
        // Switch players
        Player temp = currentPlayer;
        currentPlayer = opponentPlayer;
        opponentPlayer = temp;

        // Reset phase
        currentPhase = GamePhase.Draw;
        currentPlayer.DrawCard();

        Debug.Log($"Turn ended. {currentPlayer.name}'s turn begins.");
    }

    public bool CanPlayCard(Card card)
    {
        // Check if card can be played in current phase
        if (currentPhase == GamePhase.Main)
        {
            if (card.cardType == CardType.Terrain)
            {
                return currentPlayer.GetTerrainCount() < maxTerrainCards;
            }
            return true;
        }
        return false;
    }

    public void CheckGameEnd()
    {
        if (currentPlayer.lifePoints <= 0 || currentPlayer.deck.Count == 0)
        {
            EndGame(opponentPlayer);
        }
        else if (opponentPlayer.lifePoints <= 0 || opponentPlayer.deck.Count == 0)
        {
            EndGame(currentPlayer);
        }
    }

    private void EndGame(Player winner)
    {
        isGameStarted = false;
        Debug.Log($"Game Over! {winner.name} wins!");
    }
} 