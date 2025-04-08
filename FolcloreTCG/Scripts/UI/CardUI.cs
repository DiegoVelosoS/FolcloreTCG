using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class CardUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Card card;
    public Image cardImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI effectText;
    public CanvasGroup canvasGroup;

    private Vector3 originalPosition;
    private Transform originalParent;
    private bool isDragging = false;
    private bool isHovering = false;

    public void Initialize(Card card)
    {
        this.card = card;
        nameText.text = card.cardName;
        typeText.text = card.type.ToString();
        powerText.text = card.type == CardType.Criatura ? $"Poder: {card.power}" : "";
        effectText.text = card.effect;
        // Aqui você deve carregar a imagem da carta
        // cardImage.sprite = Resources.Load<Sprite>($"Cards/{card.cardName}");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!GameManager.Instance.isPlayerTurn || GameManager.Instance.currentPhase != GameManager.GamePhase.Preparation)
            return;

        isDragging = true;
        originalPosition = transform.position;
        originalParent = transform.parent;
        transform.SetParent(UIManager.Instance.transform);
        canvasGroup.blocksRaycasts = false;

        // Tocar som de seleção
        AudioManager.Instance.Play("CardSelect");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragging) return;

        isDragging = false;
        canvasGroup.blocksRaycasts = true;

        // Verificar se a carta foi solta em uma área válida
        CardZone targetZone = GetDropZone(eventData.position);
        if (targetZone != CardZone.None)
        {
            // Tocar som de jogada de carta
            AudioManager.Instance.PlayCardSound();
            
            // Iniciar animação de jogada
            StartCoroutine(AnimationManager.Instance.PlayCardAnimation(transform, eventData.position));
            
            GameManager.Instance.player.PlayCard(card, targetZone);
        }
        else
        {
            // Retornar a carta para a posição original
            transform.SetParent(originalParent);
            StartCoroutine(AnimationManager.Instance.PlayCardAnimation(transform, originalPosition));
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isDragging)
        {
            isHovering = true;
            StartCoroutine(AnimationManager.Instance.HoverCardAnimation(transform, true));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isDragging)
        {
            isHovering = false;
            StartCoroutine(AnimationManager.Instance.HoverCardAnimation(transform, false));
        }
    }

    private CardZone GetDropZone(Vector3 position)
    {
        // Implementar lógica para detectar em qual zona a carta foi solta
        // Retornar CardZone.Terrain, CardZone.Field ou CardZone.None
        return CardZone.None;
    }

    public void PlayAttackAnimation(Transform target)
    {
        StartCoroutine(AnimationManager.Instance.AttackAnimation(transform, target));
        AudioManager.Instance.PlayAttackSound();
    }

    public void PlayDestroyAnimation()
    {
        StartCoroutine(AnimationManager.Instance.DestroyCardAnimation(transform));
    }
} 