using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance { get; private set; }

    [System.Serializable]
    public class TutorialStep
    {
        public string title;
        public string description;
        public Sprite image;
        public bool requiresInteraction;
        public string interactionTarget;
    }

    [Header("Configurações do Tutorial")]
    public TutorialStep[] tutorialSteps;
    public GameObject tutorialPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image tutorialImage;
    public Button nextButton;
    public Button skipButton;

    private int currentStep = 0;
    private bool isTutorialActive = false;

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
        tutorialPanel.SetActive(false);
        nextButton.onClick.AddListener(NextStep);
        skipButton.onClick.AddListener(SkipTutorial);
    }

    public void StartTutorial()
    {
        if (tutorialSteps.Length == 0) return;

        isTutorialActive = true;
        currentStep = 0;
        ShowCurrentStep();
    }

    private void ShowCurrentStep()
    {
        if (currentStep >= tutorialSteps.Length)
        {
            EndTutorial();
            return;
        }

        TutorialStep step = tutorialSteps[currentStep];
        titleText.text = step.title;
        descriptionText.text = step.description;
        tutorialImage.sprite = step.image;
        tutorialPanel.SetActive(true);

        if (step.requiresInteraction)
        {
            nextButton.gameObject.SetActive(false);
            // Implementar lógica para esperar interação específica
        }
        else
        {
            nextButton.gameObject.SetActive(true);
        }
    }

    public void NextStep()
    {
        currentStep++;
        ShowCurrentStep();
    }

    public void SkipTutorial()
    {
        EndTutorial();
    }

    private void EndTutorial()
    {
        isTutorialActive = false;
        tutorialPanel.SetActive(false);
        // Salvar que o tutorial foi completado
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        PlayerPrefs.Save();
    }

    public void CheckInteraction(string interactionName)
    {
        if (!isTutorialActive) return;

        TutorialStep current = tutorialSteps[currentStep];
        if (current.requiresInteraction && current.interactionTarget == interactionName)
        {
            NextStep();
        }
    }

    public bool IsTutorialActive()
    {
        return isTutorialActive;
    }
} 