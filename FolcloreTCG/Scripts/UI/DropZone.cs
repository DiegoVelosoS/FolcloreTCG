using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public CardZone zoneType;
    public int maxCards = 0; // 0 = ilimitado

    public void OnDrop(PointerEventData eventData)
    {
        CardUI cardUI = eventData.pointerDrag.GetComponent<CardUI>();
        if (cardUI != null && CanAcceptCard(cardUI.card))
        {
            // Verificar se a zona já atingiu o limite de cartas
            if (maxCards > 0 && transform.childCount >= maxCards)
            {
                return;
            }

            // Mover a carta para esta zona
            cardUI.transform.SetParent(transform);
            cardUI.transform.localPosition = Vector3.zero;

            // Notificar o GameManager sobre a jogada
            GameManager.Instance.player.PlayCard(cardUI.card, zoneType);
        }
    }

    private bool CanAcceptCard(Card card)
    {
        switch (zoneType)
        {
            case CardZone.Terrain:
                return card.type == CardType.Terreno;
            case CardZone.Field:
                return card.type == CardType.Criatura || card.type == CardType.Suporte;
            default:
                return false;
        }
    }
} 