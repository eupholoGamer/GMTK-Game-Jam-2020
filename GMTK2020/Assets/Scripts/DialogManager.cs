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
    DialogChoices[] dialogChoices = { new DialogChoices("TEST1", 1, 4, 1, 2, 3), new DialogChoices("TEST2", 2, 5, 3, 1, 2), new DialogChoices("TEST3", 3, 6, 2, 3, 1)};

    // Array of possible speech
    string[] speeches = {"SPEECHTEST1",  "SPEECHTEST2", "SPEECHTEST3", "SPEECHTEST4", "SPEECHTEST5", "SPEECHTEST6"};

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
        selected = dialogChoices[0];
        speech.text = "LET'S-A GO TEST SOME DIALOGUE MAMMA MIA MEAT-A-BALL-A";

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
