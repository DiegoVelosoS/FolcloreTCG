using UnityEngine;

public class FlorestaAmazonicaCard : TerrainCard
{
    private void Start()
    {
        cardName = "Floresta Amazônica";
        type = CardType.Terreno;
        terrainType = "Floresta";
        effect = "Todas as criaturas do tipo Floresta ganham +1 de poder enquanto este terreno estiver no campo.";
    }

    public override void PlayCard()
    {
        base.PlayCard();
        // Implementar efeito de aumentar poder das criaturas
    }
} 