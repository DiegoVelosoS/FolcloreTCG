using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Referências de UI")]
    public TextMeshProUGUI playerLifeText;
    public TextMeshProUGUI opponentLifeText;
    public TextMeshProUGUI phaseText;
    public GameObject cardPrefab;
    public Transform playerHandContainer;
    public Transform playerFieldContainer;
    public Transform opponentFieldContainer;
    public Transform terrainContainer;

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

    public void UpdateLifePoints(int playerLife, int opponentLife)
    {
        playerLifeText.text = $"Vida: {playerLife}";
        opponentLifeText.text = $"Vida: {opponentLife}";
    }

    public void UpdatePhase(GameManager.GamePhase phase)
    {
        string phaseName = "";
        switch (phase)
        {
            case GameManager.GamePhase.Draw:
                phaseName = "Fase de Compra";
                break;
            case GameManager.GamePhase.Main:
                phaseName = "Fase Principal";
                break;
            case GameManager.GamePhase.Battle:
                phaseName = "Fase de Batalha";
                break;
            case GameManager.GamePhase.End:
                phaseName = "Fase Final";
                break;
        }
        phaseText.text = $"Fase: {phaseName}";
    }

    public void CreateCardInHand(Card card)
    {
        GameObject cardObj = Instantiate(cardPrefab, playerHandContainer);
        CardDisplay display = cardObj.GetComponent<CardDisplay>();
        display.SetupCard(card);
    }

    public void UpdateField(List<Card> playerField, List<Card> opponentField, List<Card> terrainCards)
    {
        // Limpa os containers
        foreach (Transform child in playerFieldContainer)
            Destroy(child.gameObject);
        foreach (Transform child in opponentFieldContainer)
            Destroy(child.gameObject);
        foreach (Transform child in terrainContainer)
            Destroy(child.gameObject);

        // Atualiza o campo do jogador
        foreach (Card card in playerField)
        {
            GameObject cardObj = Instantiate(cardPrefab, playerFieldContainer);
            CardDisplay display = cardObj.GetComponent<CardDisplay>();
            display.SetupCard(card);
        }

        // Atualiza o campo do oponente
        foreach (Card card in opponentField)
        {
            GameObject cardObj = Instantiate(cardPrefab, opponentFieldContainer);
            CardDisplay display = cardObj.GetComponent<CardDisplay>();
            display.SetupCard(card);
        }

        // Atualiza os terrenos
        foreach (Card card in terrainCards)
        {
            GameObject cardObj = Instantiate(cardPrefab, terrainContainer);
            CardDisplay display = cardObj.GetComponent<CardDisplay>();
            display.SetupCard(card);
        }
    }
} 