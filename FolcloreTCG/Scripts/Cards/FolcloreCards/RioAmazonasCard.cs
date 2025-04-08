using UnityEngine;

public class RioAmazonasCard : TerrainCard
{
    private void Start()
    {
        cardName = "Rio Amazonas";
        type = CardType.Terreno;
        terrainType = "Rio";
        effect = "Todas as criaturas do tipo Rio ganham +1 de poder e podem atacar diretamente o jogador oponente.";
    }

    public override void PlayCard()
    {
        base.PlayCard();
        // Implementar efeito de aumentar poder e permitir ataque direto
    }
} 