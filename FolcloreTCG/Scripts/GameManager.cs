using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int maxLifePoints = 10;
    public int initialHandSize = 5;
    public int maxTerrainCards = 4;
    public int maxCardsInDeck = 40;
    public int minCardsInDeck = 20;
    public int maxCopiesOfCard = 3;

    public enum GamePhase
    {
        Start,
        Draw,
        Preparation,
        Battle,
        End
    }

    public GamePhase currentPhase;
    public bool isPlayerTurn;

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

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        currentPhase = GamePhase.Start;
        isPlayerTurn = Random.value > 0.5f; // Decide quem começa
    }

    public void StartTurn()
    {
        currentPhase = GamePhase.Draw;
        // Lógica para comprar carta
    }

    public void EndTurn()
    {
        isPlayerTurn = !isPlayerTurn;
        currentPhase = GamePhase.Start;
    }

    public void CheckGameEnd()
    {
        // Verificar condições de vitória/derrota
    }
} 