using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using System.IO;

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
    NavMeshAgent crimsonNav;

    // public array of waypoints for Crimson's and scripted guard movement, populated in editor
    public Transform[] storyWaypoints;

    // string for controlling which character is displayed in UI
    string speaking;

    // public array to connect interactible objects
    public GameObject[] interactables;

    // fields for story checkpoints/variables
    public int mood;
    public bool nameMentioned;
    public bool fireStarted;
    public int storyBeat;

    

    // bool for watching whether an event has ended, set to false at the beginning of each event and true when the countdown reaches 0
    [SerializeField]
    bool eventEnded;

    // Start is called before the first frame update
    void Start()
    {
        mood = 0;
        nameMentioned = false;
        fireStarted = false;
        storyBeat = 0;
        crimsonNav = crimson.GetComponent<NavMeshAgent>();
        eventEnded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (eventEnded)
        {
            if (storyBeat == 0)
            {
                StartCoroutine(StoryBeat0());
            }
            else if (storyBeat == 1)
            {
                eventEnded = false;
                Debug.Log("THANK FUCK WE GOT THIS FAR");
            }
        }
        /*
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
        */
        

        
    }

    IEnumerator StoryBeat0()
    {
        eventEnded = false;

        optionsContainer.SetActive(false);
        speechContainer.SetActive(true);

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Alright...you ready? I hate that I'm not the one on the ground.";
        yield return new WaitForSeconds(3);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "I'm always ready. And you did lose a whole FIVE rounds of Rock Paper Scissors, so... That's how it is!";
        yield return new WaitForSeconds(5);

        speaking = "Dark";
        textMeshProUGUIs[0].text = "You Cheated!";
        textMeshProUGUIs[1].text = "I'm way more qualified!";
        textMeshProUGUIs[2].text = "Fine... Good luck.";

        speechContainer.SetActive(false);
        optionsContainer.SetActive(true);

        yield return new WaitUntil(() => Input.anyKeyDown);
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            optionsContainer.SetActive(false);
            speechContainer.SetActive(true);

            textMeshProUGUIs[3].text = "But you cheated!";
            yield return new WaitForSeconds(2);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Well... You didn't catch me in the moment.";
            yield return new WaitForSeconds(3);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Wait, I was joking. How did you cheat at Rock Paper Scissors?!";
            yield return new WaitForSeconds(4);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "I have my ways.";
            yield return new WaitForSeconds(3);

            speaking = "Dark";
            textMeshProUGUIs[0].text = "Impressive...";
            textMeshProUGUIs[1].text = "It's still wrong.";
            textMeshProUGUIs[2].text = "Alright, let's go in.";

            speechContainer.SetActive(false);
            optionsContainer.SetActive(true);

            yield return new WaitUntil(() => Input.anyKeyDown);
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                optionsContainer.SetActive(false);
                speechContainer.SetActive(true);

                textMeshProUGUIs[3].text = "Impressive...";
                yield return new WaitForSeconds(2);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "I know more than you think!";
                yield return new WaitForSeconds(3);

                speaking = "Dark";
                textMeshProUGUIs[0].text = "Alright, let's go in.";
                textMeshProUGUIs[1].text = "Alright, let's go in.";
                textMeshProUGUIs[2].text = "Alright, let's go in.";

                speechContainer.SetActive(false);
                optionsContainer.SetActive(true);

                yield return new WaitUntil(() => Input.anyKeyDown);

                storyBeat = 1;
                eventEnded = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                optionsContainer.SetActive(false);
                speechContainer.SetActive(true);

                textMeshProUGUIs[3].text = "That's wrong, you shouldn't cheat at a thing like that!";
                yield return new WaitForSeconds(2);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Dark, we're spies. We gotta know how to get the things we want!";
                yield return new WaitForSeconds(3);

                speaking = "Dark";
                textMeshProUGUIs[0].text = "We're supposed to be a team!";
                textMeshProUGUIs[1].text = "Alright, let's go in.";
                textMeshProUGUIs[2].text = "Alright, let's go in.";

                speechContainer.SetActive(false);
                optionsContainer.SetActive(true);

                yield return new WaitUntil(() => Input.anyKeyDown);

                if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                {
                    optionsContainer.SetActive(false);
                    speechContainer.SetActive(true);

                    textMeshProUGUIs[3].text = "Yeah, but you can't cheat against me! We're supposed to be a team! Work together, and all that!";
                    yield return new WaitForSeconds(2);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "I suppose so... Wanna be on the ground for the next op?";
                    yield return new WaitForSeconds(3);

                    speaking = "Dark";
                    textMeshProUGUIs[0].text = "I'd like that.";
                    textMeshProUGUIs[1].text = "I'd rather have a fair rematch.";
                    textMeshProUGUIs[2].text = "Let's just go in.";

                    speechContainer.SetActive(false);
                    optionsContainer.SetActive(true);

                    yield return new WaitUntil(() => Input.anyKeyDown);

                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
                    {
                        optionsContainer.SetActive(false);
                        speechContainer.SetActive(true);

                        textMeshProUGUIs[3].text = "I'd like that...";
                        yield return new WaitForSeconds(3);

                        speaking = "Crimson";
                        textMeshProUGUIs[3].text = "Fine. But this one's mine.";
                        yield return new WaitForSeconds(3);

                        speaking = "Dark";
                        textMeshProUGUIs[0].text = "Alright, let's go in.";
                        textMeshProUGUIs[1].text = "Alright, let's go in.";
                        textMeshProUGUIs[2].text = "Alright, let's go in.";

                        speechContainer.SetActive(false);
                        optionsContainer.SetActive(true);

                        yield return new WaitUntil(() => Input.anyKeyDown);

                        storyBeat = 1;
                        eventEnded = true;
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
                    {
                        optionsContainer.SetActive(false);
                        speechContainer.SetActive(true);

                        textMeshProUGUIs[3].text = "I'd rather have a rematch, fair and square!";
                        yield return new WaitForSeconds(3);

                        speaking = "Crimson";
                        textMeshProUGUIs[3].text = "Whatever you say. I know all your tells, though.";
                        yield return new WaitForSeconds(3);

                        speaking = "Dark";
                        textMeshProUGUIs[0].text = "Alright, let's go in.";
                        textMeshProUGUIs[1].text = "Alright, let's go in.";
                        textMeshProUGUIs[2].text = "Alright, let's go in.";

                        speechContainer.SetActive(false);
                        optionsContainer.SetActive(true);

                        yield return new WaitUntil(() => Input.anyKeyDown);

                        storyBeat = 1;
                        eventEnded = true;
                    }
                    else
                    {
                        storyBeat = 1;
                        eventEnded = true;
                    }
                }
                else
                {
                    storyBeat = 1;
                    eventEnded = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                storyBeat = 1;
                eventEnded = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            optionsContainer.SetActive(false);
            speechContainer.SetActive(true);

            textMeshProUGUIs[3].text = "I'm better qualified! You're terrible at stealth!";
            yield return new WaitForSeconds(3);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "I'm alright! And besides, I can usually charm my way out.";
            yield return new WaitForSeconds(3);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Hnngh...";
            yield return new WaitForSeconds(2);

            speaking = "Dark";
            textMeshProUGUIs[0].text = "That you do...";
            textMeshProUGUIs[1].text = "Alright, let's go in.";
            textMeshProUGUIs[2].text = "I don't even get caught...";

            speechContainer.SetActive(false);
            optionsContainer.SetActive(true);

            yield return new WaitUntil(() => Input.anyKeyDown);
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                optionsContainer.SetActive(false);
                speechContainer.SetActive(true);

                textMeshProUGUIs[3].text = "That you do...";
                yield return new WaitForSeconds(3);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "See? Just charmed my way out of that one.";
                yield return new WaitForSeconds(3);

                speaking = "Dark";
                textMeshProUGUIs[3].text = "Hnngh...";
                yield return new WaitForSeconds(2);

                speaking = "Dark";
                textMeshProUGUIs[0].text = "Alright, let's go in.";
                textMeshProUGUIs[1].text = "Alright, let's go in.";
                textMeshProUGUIs[2].text = "Alright, let's go in.";

                speechContainer.SetActive(false);
                optionsContainer.SetActive(true);

                yield return new WaitUntil(() => Input.anyKeyDown);

                storyBeat = 1;
                eventEnded = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                storyBeat = 1;
                eventEnded = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
            {
                optionsContainer.SetActive(false);
                speechContainer.SetActive(true);

                textMeshProUGUIs[3].text = "But I don't even get caught.";
                yield return new WaitForSeconds(3);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "You did once.";
                yield return new WaitForSeconds(3);

                textMeshProUGUIs[3].text = "Yeah, like 2 years ago!";
                yield return new WaitForSeconds(3);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "And that one time in Switzerland. How long did it take before you could bust out?";
                yield return new WaitForSeconds(3);

                speaking = "Dark";
                textMeshProUGUIs[3].text = "Hnngh...";
                yield return new WaitForSeconds(2);

                speaking = "Dark";
                textMeshProUGUIs[0].text = "Alright, let's go in.";
                textMeshProUGUIs[1].text = "Alright, let's go in.";
                textMeshProUGUIs[2].text = "Alright, let's go in.";

                speechContainer.SetActive(false);
                optionsContainer.SetActive(true);

                yield return new WaitUntil(() => Input.anyKeyDown);

                storyBeat = 1;
                eventEnded = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            optionsContainer.SetActive(false);
            speechContainer.SetActive(true);

            textMeshProUGUIs[3].text = "Fine... Good luck in there...";
            yield return new WaitForSeconds(3);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Thanks, dear.";
            yield return new WaitForSeconds(3);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Hnngh...";
            yield return new WaitForSeconds(2);

            speaking = "Dark";
            textMeshProUGUIs[0].text = "Alright, let's go in.";
            textMeshProUGUIs[1].text = "Alright, let's go in.";
            textMeshProUGUIs[2].text = "Alright, let's go in.";

            speechContainer.SetActive(false);
            optionsContainer.SetActive(true);

            yield return new WaitUntil(() => Input.anyKeyDown);

            storyBeat = 1;
            eventEnded = true;
        }
    }
}
