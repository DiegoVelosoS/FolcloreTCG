using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [Header("Referências de UI")]
    public Image cardImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI effectText;
    public TextMeshProUGUI powerText;
    public Image cardBackground;

    private Card card;
    private Button cardButton;

    private void Awake()
    {
        cardButton = GetComponent<Button>();
        cardButton.onClick.AddListener(OnCardClicked);
    }

    public void SetupCard(Card card)
    {
        this.card = card;
        
        // Atualiza a UI com os dados da carta
        nameText.text = card.cardName;
        typeText.text = GetCardTypeText(card.cardType);
        effectText.text = card.effect;
        
        // Define a cor de fundo baseada no tipo da carta
        cardBackground.color = GetCardColor(card.cardType);
        
        // Mostra o poder apenas para cartas de criatura
        powerText.gameObject.SetActive(card.cardType == CardType.Creature);
        if (card.cardType == CardType.Creature)
        {
            powerText.text = $"Poder: {card.power}";
        }
    }

    private string GetCardTypeText(CardType type)
    {
        switch (type)
        {
            case CardType.Terrain:
                return "Terreno";
            case CardType.Creature:
                return "Criatura";
            case CardType.Support:
                return "Suporte";
            default:
                return "";
        }
    }

    private Color GetCardColor(CardType type)
    {
        switch (type)
        {
            case CardType.Terrain:
                return new Color(0.2f, 0.8f, 0.2f); // Verde
            case CardType.Creature:
                return new Color(0.8f, 0.2f, 0.2f); // Vermelho
            case CardType.Support:
                return new Color(0.2f, 0.2f, 0.8f); // Azul
            default:
                return Color.white;
        }
    }

    private void OnCardClicked()
    {
        if (card != null)
        {
            // Verifica se a carta pode ser jogada
            if (GameManager.Instance.CanPlayCard(card))
            {
                // Tenta jogar a carta
                Player currentPlayer = GameManager.Instance.GetCurrentPlayer();
                currentPlayer.PlayCard(card);
            }
        }
    }
} 