using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class DeckBuilder : MonoBehaviour
{
    [Header("Referências de UI")]
    public Transform availableCardsContainer;
    public Transform deckContainer;
    public GameObject cardPrefab;
    public TextMeshProUGUI deckCountText;
    public Button saveDeckButton;
    public Button backButton;

    private List<Card> availableCards = new List<Card>();
    private List<Card> currentDeck = new List<Card>();
    private Dictionary<string, int> cardCounts = new Dictionary<string, int>();

    private void Start()
    {
        LoadAvailableCards();
        UpdateDeckCount();
        
        saveDeckButton.onClick.AddListener(SaveDeck);
        backButton.onClick.AddListener(GoBackToMainMenu);
    }

    private void LoadAvailableCards()
    {
        // Carregar todas as cartas disponíveis
        // Este é um exemplo, você precisará implementar a lógica real de carregamento
        availableCards.Add(new SaciPerereCard());
        availableCards.Add(new CurupiraCard());
        availableCards.Add(new FlorestaAmazonicaCard());
        availableCards.Add(new BenzedeiraCard());

        // Criar UI para cada carta disponível
        foreach (Card card in availableCards)
        {
            CreateCardUI(card, availableCardsContainer, true);
        }
    }

    private void CreateCardUI(Card card, Transform parent, bool isAvailableCard)
    {
        GameObject cardObject = Instantiate(cardPrefab, parent);
        CardUI cardUI = cardObject.GetComponent<CardUI>();
        cardUI.Initialize(card);

        if (isAvailableCard)
        {
            // Adicionar listener para adicionar ao deck
            Button addButton = cardObject.GetComponent<Button>();
            addButton.onClick.AddListener(() => AddCardToDeck(card));
        }
        else
        {
            // Adicionar listener para remover do deck
            Button removeButton = cardObject.GetComponent<Button>();
            removeButton.onClick.AddListener(() => RemoveCardFromDeck(card));
        }
    }

    private void AddCardToDeck(Card card)
    {
        if (currentDeck.Count >= GameManager.Instance.maxCardsInDeck)
        {
            Debug.Log("Deck atingiu o limite máximo de cartas!");
            return;
        }

        string cardName = card.cardName;
        if (!cardCounts.ContainsKey(cardName))
        {
            cardCounts[cardName] = 0;
        }

        if (cardCounts[cardName] >= GameManager.Instance.maxCopiesOfCard)
        {
            Debug.Log($"Limite de {GameManager.Instance.maxCopiesOfCard} cópias desta carta atingido!");
            return;
        }

        currentDeck.Add(card);
        cardCounts[cardName]++;
        CreateCardUI(card, deckContainer, false);
        UpdateDeckCount();
    }

    private void RemoveCardFromDeck(Card card)
    {
        if (currentDeck.Remove(card))
        {
            cardCounts[card.cardName]--;
            UpdateDeckCount();
        }
    }

    private void UpdateDeckCount()
    {
        deckCountText.text = $"Cartas no Deck: {currentDeck.Count}/{GameManager.Instance.maxCardsInDeck}";
        saveDeckButton.interactable = currentDeck.Count >= GameManager.Instance.minCardsInDeck;
    }

    private void SaveDeck()
    {
        if (currentDeck.Count < GameManager.Instance.minCardsInDeck)
        {
            Debug.Log($"O deck precisa ter pelo menos {GameManager.Instance.minCardsInDeck} cartas!");
            return;
        }

        // Implementar lógica para salvar o deck
        // Por exemplo, usando PlayerPrefs ou um sistema de arquivos
        Debug.Log("Deck salvo com sucesso!");
    }

    private void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
} 