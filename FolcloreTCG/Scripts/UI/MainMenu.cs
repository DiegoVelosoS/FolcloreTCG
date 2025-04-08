using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Botões do Menu")]
    public Button playButton;
    public Button deckBuilderButton;
    public Button optionsButton;
    public Button quitButton;

    private void Start()
    {
        // Configurar listeners dos botões
        playButton.onClick.AddListener(OnPlayButtonClicked);
        deckBuilderButton.onClick.AddListener(OnDeckBuilderButtonClicked);
        optionsButton.onClick.AddListener(OnOptionsButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        // Carregar cena do jogo
        SceneManager.LoadScene("GameScene");
    }

    private void OnDeckBuilderButtonClicked()
    {
        // Carregar cena do construtor de deck
        SceneManager.LoadScene("DeckBuilderScene");
    }

    private void OnOptionsButtonClicked()
    {
        // Abrir menu de opções
        // Implementar lógica do menu de opções
    }

    private void OnQuitButtonClicked()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
} 