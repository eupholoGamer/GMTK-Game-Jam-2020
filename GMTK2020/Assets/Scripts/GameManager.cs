using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // public array of fields to connect TMPro, populated in editor. 1-3 for dialogue choices, 4 for speech boxes
    public TextMeshProUGUI[] textMeshProUGUIs = new TextMeshProUGUI[4];

    // public GameObjects to connect UI containers, populated in editor
    public GameObject speechContainer;
    public GameObject optionsContainer;

    // public image to connect portrait frame, populated in editor
    public Image portrait;

    // public GameObject to connect Crimson, populated in editor
    public GameObject crimson;

    // public array to connect interactible objects
    public GameObject[] interactables;

    // fields for story checkpoints/variables
    public int mood;
    public bool nameMentioned;
    public bool fireStarted;
    public float storyBeat;

    // floats for counting down time for movement, dialogue, events
    [SerializeField]
    float countdown;
    [SerializeField]
    float subcountdown;

    // bool for watching whether an event has ended, set to false at the beginning of each event and true when the countdown reaches 0
    [SerializeField]
    bool eventEnded;

    // Start is called before the first frame update
    void Start()
    {
        mood = 0;
        nameMentioned = false;
        fireStarted = false;
        storyBeat = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // action is happening any time countdown >= 0, input is happening any time countdown < 0
        if (countdown >= 0)
        {
            if (storyBeat == 0.0f)
            {
                eventEnded = false;
                optionsContainer.SetActive(false);
                speechContainer.SetActive(true);
                // insert dialog, VO, and movement associated with this beat/subbeat
            }
            else if (storyBeat == 0.1f)
            {
                eventEnded = false;
                optionsContainer.SetActive(false);
                speechContainer.SetActive(true);
                // insert dialog, VO, and movement associated with this beat/subbeat
            }
        }
        else if (countdown < 0)
        {
            eventEnded = true;
            if (storyBeat == 0.0f)
            {
                textMeshProUGUIs[0].text = "OPTION 1";
                textMeshProUGUIs[1].text = "OPTION 2";
                textMeshProUGUIs[2].text = "OPTION 3";

                speechContainer.SetActive(false);
                optionsContainer.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {
                    // set storyBeat to the appropriate subBeat for choice 1, set countdown to the appropriate amount of time
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                {
                    // set storyBeat to the appropriate subBeat for choice 2, set countdown to the appropriate amount of time
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                {
                    // set storyBeat to the appropriate subBeat for choice 3, set countdown to the appropriate amount of time
                }
            }
            else if (storyBeat == 0.1f)
            {
                textMeshProUGUIs[0].text = "OPTION 1";
                textMeshProUGUIs[1].text = "OPTION 2";
                textMeshProUGUIs[2].text = "OPTION 3";

                speechContainer.SetActive(false);
                optionsContainer.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {
                    // set storyBeat to the appropriate subBeat for choice 1, set countdown to the appropriate amount of time
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                {
                    // set storyBeat to the appropriate subBeat for choice 2, set countdown to the appropriate amount of time
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
                {
                    // set storyBeat to the appropriate subBeat for choice 3, set countdown to the appropriate amount of time
                }
            }
        }

        if (!eventEnded)
        {
            countdown -= Time.deltaTime;
            subcountdown -= Time.deltaTime;
        }
    }
}
