using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
    DialogChoices[] dialogChoices = { new DialogChoices("TEST1", 1, 1, 2, 3), new DialogChoices("TEST2", 2, 3, 1, 2), new DialogChoices("TEST3", 3, 2, 3, 1)};

    // Array of possible speech
    string[] speeches = {"SPEECHTEST1",  "SPEECHTEST2", "SPEECHTEST3"};

    // bool to determine state (true - dialog options, false - speech)
    [SerializeField]
    bool isDialog;

    // Start is called before the first frame update
    void Start()
    {
        
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
            // code for speech goes here
        }
        else
        {
            Debug.Log("isDialog not assigned");
            isDialog = false;
        }
    }

    void UpdateDialogChoices()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("UpdateUI called");
    }
}
