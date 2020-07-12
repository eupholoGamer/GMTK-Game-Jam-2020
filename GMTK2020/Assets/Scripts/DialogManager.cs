using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    // timer for switching speeches back to choices
    [SerializeField]
    float timer = 5.0f;
    bool speech1 = true;

    // Containers for enabling/disabling TMPro because that's not a native option, assigned in editor
    public GameObject optionsContainer;
    public GameObject speechContainer;

    // Public field to attach portrait image to
    public Image portrait;

    // Public fields to attach textboxes to, assigned in editor
    public TextMeshProUGUI option1;
    public TextMeshProUGUI option2;
    public TextMeshProUGUI option3;
    public TextMeshProUGUI speech;

    
    // Array to fill with current DialogChoices
    DialogChoices[] currentChoices = new DialogChoices[3];
    DialogChoices selected;

    // Array of possible dialog choices
    DialogChoices[] dialogChoices = { 
        new DialogChoices("You cheated!", 3, 4, 4, 5, 6), 
        new DialogChoices("I'm better qualified!", 5, 6, 7, 8, 6), 
        new DialogChoices("Fine...good luck.", 3, 6, 2, 3, 1),
        new DialogChoices("Impressive", 3, 6, 2, 3, 1),
        new DialogChoices("It's still wrong!", 3, 6, 2, 3, 1),
        new DialogChoices("Alright, let's go in", 3, 6, 2, 3, 1),
        new DialogChoices("That you do...", 3, 6, 2, 3, 1),
        new DialogChoices("I don't even get caught...", 3, 6, 2, 3, 1)
        };

    // Array of possible speech
    string[] speeches = {"Alright...you ready? I hate that I'm not the one on the ground...",  
        "I'm always ready! And you did lose FIVE rounds of Rock Paper Scissors, so...that's how it is!", 
        "I don't know how but I bet you cheated!", 
        "I have my ways, it's not my fault you didn't catch me in the moment", 
        "I'm better qualified! You're terrible at stealth!", 
        "I'm alright! Besides, I can usually charm my way out."};

    // bool to determine state (true - dialog options, false - speech)
    [SerializeField]
    bool isDialog;

    // Start is called before the first frame update
    void Start()
    {
        // assigning starting values to all UI objects
        currentChoices[0] = dialogChoices[0];
        currentChoices[1] = dialogChoices[1];
        currentChoices[2] = dialogChoices[2];
        selected = new DialogChoices("", 1, 2, 1, 2, 3);
        speech.text = speeches[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (isDialog)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            {
                selected = currentChoices[0];
                UpdateUI();
                isDialog = false;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                selected = currentChoices[1];
                UpdateUI();
                isDialog = false;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            {
                selected = currentChoices[2];
                UpdateUI();
                isDialog = false;
            }
        }
        else if (!isDialog)
        {
            if (speech1 && timer >= 0.0f)
            {
                timer -= Time.deltaTime;
            }
            else if (speech1)
            {
                speech.text = speeches[selected.speech2 - 1];
                speech1 = false;
                timer = 5.0f;
            }
            else if (timer >= 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                UpdateUI();
                isDialog = true;
                speech1 = true;
                timer = 5.0f;
            }
            // code for speech part 1 goes here
        }
        else
        {
            Debug.Log("isDialog not assigned");
            isDialog = false;
        }
    }

    void UpdateDialogChoices()
    {
        option1.text = " - " + currentChoices[0].text;
        option2.text = " - " + currentChoices[1].text;
        option3.text = " - " + currentChoices[2].text;
    }

    void UpdateUI()
    {
        //Debug.Log("UpdateUI called");
        if (isDialog)
        {
            optionsContainer.SetActive(false);
            speech.text = speeches[selected.speech1 - 1];
            speech1 = true;
            speechContainer.SetActive(true);
        }
        else
        {
            speechContainer.SetActive(false);
            currentChoices[0] = dialogChoices[selected.next[0] - 1];
            currentChoices[1] = dialogChoices[selected.next[1] - 1];
            currentChoices[2] = dialogChoices[selected.next[2] - 1];
            UpdateDialogChoices();
            optionsContainer.SetActive(true);
        }
    }
}
