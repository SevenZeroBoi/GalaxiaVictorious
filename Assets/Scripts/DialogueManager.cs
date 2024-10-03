using TMPro;
using UnityEngine;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{

    private static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("tak 1 souy p syou");
        }
        instance = this;
    }


    [Header("Dialogue UI Panel")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private Story currentStory;

    private bool isDialoguePlaying;

    private void Start()
    {
        isDialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        isDialoguePlaying = true;
        dialoguePanel.SetActive(true);

        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void ExitDialogueMode()
    {
        isDialoguePlaying = false;
        dialogueText.text = "";
    }
}
