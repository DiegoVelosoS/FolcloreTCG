using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class DeckManager : MonoBehaviour
{
    private const string SAVE_FOLDER = "Decks";
    private const string SAVE_EXTENSION = ".json";

    public static DeckManager Instance { get; private set; }

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
        CreateSaveFolder();
    }

    private void CreateSaveFolder()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, SAVE_FOLDER);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }

    public void SaveDeck(string deckName, List<Card> cards)
    {
        DeckData deckData = new DeckData(deckName, cards);
        string json = JsonUtility.ToJson(deckData, true);
        string filePath = GetDeckFilePath(deckName);
        File.WriteAllText(filePath, json);
        Debug.Log($"Deck salvo em: {filePath}");
    }

    public List<Card> LoadDeck(string deckName)
    {
        string filePath = GetDeckFilePath(deckName);
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            DeckData deckData = JsonUtility.FromJson<DeckData>(json);
            return ConvertCardNamesToCards(deckData.cardNames);
        }
        return null;
    }

    public List<string> GetSavedDeckNames()
    {
        List<string> deckNames = new List<string>();
        string folderPath = Path.Combine(Application.persistentDataPath, SAVE_FOLDER);
        string[] files = Directory.GetFiles(folderPath, $"*{SAVE_EXTENSION}");

        foreach (string file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);
            deckNames.Add(fileName);
        }

        return deckNames;
    }

    private string GetDeckFilePath(string deckName)
    {
        return Path.Combine(Application.persistentDataPath, SAVE_FOLDER, deckName + SAVE_EXTENSION);
    }

    private List<Card> ConvertCardNamesToCards(List<string> cardNames)
    {
        List<Card> cards = new List<Card>();
        foreach (string cardName in cardNames)
        {
            Card card = CreateCardFromName(cardName);
            if (card != null)
            {
                cards.Add(card);
            }
        }
        return cards;
    }

    private Card CreateCardFromName(string cardName)
    {
        // Implementar lógica para criar cartas a partir dos nomes
        // Este é um exemplo básico, você precisará implementar a lógica real
        switch (cardName)
        {
            case "Saci-Pererê":
                return new SaciPerereCard();
            case "Curupira":
                return new CurupiraCard();
            case "Floresta Amazônica":
                return new FlorestaAmazonicaCard();
            case "Benzedeira":
                return new BenzedeiraCard();
            case "Boitatá":
                return new BoitataCard();
            case "Boto":
                return new BotoCard();
            case "Rio Amazonas":
                return new RioAmazonasCard();
            case "Pajé":
                return new PajeCard();
            default:
                Debug.LogWarning($"Carta não encontrada: {cardName}");
                return null;
        }
    }
} 