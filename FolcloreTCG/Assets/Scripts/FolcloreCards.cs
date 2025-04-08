using UnityEngine;
using System.Collections.Generic;

public static class FolcloreCards
{
    public static List<Card> CreateStarterDeck()
    {
        List<Card> deck = new List<Card>();

        // Cartas de Terreno
        deck.Add(CreateTerrainCard("Floresta Amazônica", "Floresta", "Permite invocar criaturas da floresta"));
        deck.Add(CreateTerrainCard("Sertão Nordestino", "Deserto", "Aumenta o poder das criaturas do sertão"));
        deck.Add(CreateTerrainCard("Praia de Ipanema", "Praia", "Permite invocar criaturas aquáticas"));
        deck.Add(CreateTerrainCard("Cerrado Brasileiro", "Cerrado", "Aumenta a defesa das criaturas"));

        // Cartas de Criatura
        deck.Add(CreateCreatureCard("Saci-Pererê", "Floresta", "Pode atacar diretamente o oponente", 3));
        deck.Add(CreateCreatureCard("Curupira", "Floresta", "Protege outras criaturas da floresta", 4));
        deck.Add(CreateCreatureCard("Iara", "Praia", "Pode controlar criaturas aquáticas", 3));
        deck.Add(CreateCreatureCard("Cuca", "Floresta", "Pode devorar criaturas menores", 5));
        deck.Add(CreateCreatureCard("Boto Cor-de-Rosa", "Praia", "Pode confundir o oponente", 2));
        deck.Add(CreateCreatureCard("Mula sem Cabeça", "Sertão", "Ataca todas as criaturas inimigas", 4));

        // Cartas de Suporte
        deck.Add(CreateSupportCard("Boitatá", "Floresta", "Protege todas as criaturas do fogo"));
        deck.Add(CreateSupportCard("Lobisomem", "Sertão", "Aumenta o poder das criaturas à noite"));
        deck.Add(CreateSupportCard("Vitória-Régia", "Praia", "Cura criaturas aquáticas"));
        deck.Add(CreateSupportCard("Mapinguari", "Floresta", "Aumenta a defesa de todas as criaturas"));

        return deck;
    }

    private static Card CreateTerrainCard(string name, string terrainType, string effect)
    {
        TerrainCard card = new GameObject(name).AddComponent<TerrainCard>();
        card.cardName = name;
        card.terrainType = terrainType;
        card.effect = effect;
        return card;
    }

    private static Card CreateCreatureCard(string name, string terrainType, string effect, int power)
    {
        CreatureCard card = new GameObject(name).AddComponent<CreatureCard>();
        card.cardName = name;
        card.terrainType = terrainType;
        card.effect = effect;
        card.power = power;
        return card;
    }

    private static Card CreateSupportCard(string name, string terrainType, string effect)
    {
        SupportCard card = new GameObject(name).AddComponent<SupportCard>();
        card.cardName = name;
        card.terrainType = terrainType;
        card.effect = effect;
        return card;
    }
} 