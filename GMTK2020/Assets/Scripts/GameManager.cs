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
    public bool cameraChoice;
    public bool doorKicked;
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
        cameraChoice = false;
        doorKicked = false;
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
                Debug.Log("THANK FUCK WE GOT THIS FAR");
                StartCoroutine(StoryBeat1());
            }
            else if (storyBeat == 2)
            {
                Debug.Log("Home stretch! Forgot to hardcode a BUNCH of variables before this point! WEEEEE");
                StartCoroutine(StoryBeat2());
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
        yield return new WaitForSeconds(5);

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

    IEnumerator StoryBeat1()
    {
        eventEnded = false;

        optionsContainer.SetActive(false);
        speechContainer.SetActive(true);

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Alright, let's go in... Sneak past five guards, get into a security-monitored room holding we don't know what...";
        yield return new WaitForSeconds(5);

        crimsonNav.SetDestination(storyWaypoints[0].position);

        textMeshProUGUIs[3].text = "You ready Crimson? Oh you're already going in.";
        yield return new WaitForSeconds(5);

        speaking = "Desk Clerk";
        textMeshProUGUIs[3].text = "Hello, do you have an appointment, Miss...?";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Foreign, Ann Foreign. I have an appointment with Matthew Snowmeadow, the owner?";
        yield return new WaitForSeconds(5);

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Always that same name...";
        yield return new WaitForSeconds(5);

        speaking = "Desk Clerk";
        textMeshProUGUIs[3].text = "Oh, of course! If you don't mind, David here will escort you to his office.";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Of course!";
        yield return new WaitForSeconds(5);

        speaking = "Dark";
        textMeshProUGUIs[0].text = "That was easy.";
        textMeshProUGUIs[1].text = "Good job.";
        textMeshProUGUIs[2].text = "That name...";

        speechContainer.SetActive(false);
        optionsContainer.SetActive(true);

        yield return new WaitUntil(() => Input.anyKeyDown);
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // That was easy.
        {
            optionsContainer.SetActive(false);
            speechContainer.SetActive(true);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "That was easy.";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "I did some planning.";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // Good job.
        {
            optionsContainer.SetActive(false);
            speechContainer.SetActive(true);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Good job.";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "I did some planning.";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) // That name...
        {
            optionsContainer.SetActive(false);
            speechContainer.SetActive(true);

            nameMentioned = true;

            speaking = "Dark";
            textMeshProUGUIs[3].text = "You'll get caught one day if you keep using that same name...";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "I like it though!";
        }

        crimsonNav.SetDestination(storyWaypoints[1].position);

        yield return new WaitForSeconds(5);

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Now, try and get--";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Oh, excuse me, David was it? I'm very sorry but I need to use the restroom.";
        yield return new WaitForSeconds(5);
        textMeshProUGUIs[3].text = "Wouldn't be good to go to an appointment and all, ahah. Could you show me the way?";
        yield return new WaitForSeconds(5);

        speaking = "David";
        textMeshProUGUIs[3].text = "Umm... Sure? It's just over there. I'll be waiting here arounf the corner.";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Okay!";
        yield return new WaitForSeconds(5);

        crimsonNav.SetDestination(storyWaypoints[2].position);

        speaking = "Dark";
        textMeshProUGUIs[3].text = "That worked... But don't be too suspicious.";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Of course, of course.";
        yield return new WaitForSeconds(5);

        speaking = "David";
        textMeshProUGUIs[3].text = "Hmm?";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Oh, nothing.";
        yield return new WaitForSeconds(5);

        speaking = "Dark";
        textMeshProUGUIs[0].text = "What now?";
        textMeshProUGUIs[1].text = "Sneak out behind and past him.";
        textMeshProUGUIs[2].text = "Any way of getting around?";

        speechContainer.SetActive(false);
        optionsContainer.SetActive(true);

        yield return new WaitUntil(() => Input.anyKeyDown);

        optionsContainer.SetActive(false);
        speechContainer.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // What now?
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "What now?";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Cause some noise somewhere to distract him, sneak out behind him while he isn't looking.";
            yield return new WaitForSeconds(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // Sneak out behind and past him.
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "Maybe try and sneak behind and past him while he isn't looking?";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "I was thinking more like... cause some noise somewhere else, distract him with that, and THEN sneak past him.";
            yield return new WaitForSeconds(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) // Any way of getting around?
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "Any way of getting around? That maintenance door, maybe?";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "I'd rather do something more fun than using a maintenance door.";
            yield return new WaitForSeconds(5);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "What are you planning?";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "I'm gonna make some noise, distract the guard with that, then sneak past him.";
            yield return new WaitForSeconds(5);
        }

        speaking = "Dark";
        textMeshProUGUIs[0].text = "What sorta noise?";
        textMeshProUGUIs[1].text = "Please just use the door...";
        textMeshProUGUIs[2].text = "Don't make them anxious...";

        speechContainer.SetActive(false);
        optionsContainer.SetActive(true);

        yield return new WaitUntil(() => Input.anyKeyDown);

        optionsContainer.SetActive(false);
        speechContainer.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // What sorta noise?
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "What sorta noise?";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "You'll see!";
            yield return new WaitForSeconds(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // Please just use the door...
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "Could you please just use the door?";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Nope! I have something more fun planned.";
            yield return new WaitForSeconds(5);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Wh--what?";
            yield return new WaitForSeconds(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) // Don't make them anxious...
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "We shouldn't make them anxious though, it might make your job more difficult.";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "I enjoy a challenge.";
            yield return new WaitForSeconds(5);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Oh, no... What are you gonna do?";
            yield return new WaitForSeconds(5);
        }

        // Smoke grenade incident

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Are you kidding me?";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Ow, shit!";
        yield return new WaitForSeconds(5);

        // Drops grenade

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "See?";
        yield return new WaitForSeconds(5);

        // Goes to sink - sink sound effect

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Well... It looks like he's going to the front desk to check what's up. Now's your time.";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "JUST AS PLANNED!";
        yield return new WaitForSeconds(5);

        speaking = "Dark";
        textMeshProUGUIs[0].text = "Be quick!";
        textMeshProUGUIs[1].text = "Be stealthy.";
        textMeshProUGUIs[2].text = "Blend in.";

        speechContainer.SetActive(false);
        optionsContainer.SetActive(true);

        yield return new WaitUntil(() => Input.anyKeyDown);

        optionsContainer.SetActive(false);
        speechContainer.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // Be quick!
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "Be quick! While no one's around.";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Was planning on it, boss.";
            yield return new WaitForSeconds(5);

            crimsonNav.SetDestination(storyWaypoints[3].position);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "FIRE!!!";
            yield return new WaitForSeconds(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // Be stealthy.
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "Be quiet! Don't get seen.";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Of course.";
            yield return new WaitForSeconds(5);

            crimsonNav.SetDestination(storyWaypoints[3].position);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "THERE'S A FIRE IN THE BATHROOM!";
            yield return new WaitForSeconds(5);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) // Blend in.
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "Start moving! Walk like you own the place.";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Ahaha, I know how to do that.";
            yield return new WaitForSeconds(5);

            crimsonNav.SetDestination(storyWaypoints[3].position);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "THERE'S A FIRE IN THE BATHROOM!";
            yield return new WaitForSeconds(5);
        }

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Crimson...";
        yield return new WaitForSeconds(3);
        textMeshProUGUIs[3].text = "There's a door next to you, and a camera at the end of the hallway that's moving from side to side.";
        yield return new WaitForSeconds(5);

        speaking = "Dark";
        textMeshProUGUIs[0].text = "Go left when it turns away!";
        textMeshProUGUIs[1].text = "Sneak past it to the right.";
        textMeshProUGUIs[2].text = "What's through that door?";

        speechContainer.SetActive(false);
        optionsContainer.SetActive(true);

        yield return new WaitUntil(() => Input.anyKeyDown);

        optionsContainer.SetActive(false);
        speechContainer.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // Go left when it turns away!
        {
            cameraChoice = false;

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Go left while it's pointing away!";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Ehh-";
            yield return new WaitForSeconds(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // Sneak past it to the right.
        {
            cameraChoice = false;

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Sneak past it to the right while it's pointing away, then walk under and out of its line of sight!";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Ehh-";
            yield return new WaitForSeconds(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) // What's through that door?
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "What's through that door just next to you?";
            yield return new WaitForSeconds(5);

            cameraChoice = true;

            // Mood check - holy shit I haven't been hardcoding mood weeeeeeee
            if (mood >= 0)
            {
                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Not sure, I'll check inside...";
                yield return new WaitForSeconds(5);

                crimsonNav.SetDestination(storyWaypoints[4].position);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Nothing important really, just some offices.";
                yield return new WaitForSeconds(5);
            }
            else
            {
                speaking = "Crimson";
                textMeshProUGUIs[3].text = "No, I've got to keep going. The safe room is just to the left there.";
                yield return new WaitForSeconds(5);
            }
        }

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Okay, just--";
        yield return new WaitForSeconds(2);

        //Shoots camera

        if (cameraChoice)
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "I GUESS THAT WORKS?";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "And they won't be NONE the wiser. Because... Because of the fire. That I started.";
            yield return new WaitForSeconds(5);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Yes, right, the fire that you started... Alright, keep going.";
            yield return new WaitForSeconds(5);
        }
        else
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "They're gonna be looking for you now!";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Not with the fire they won't!";
            yield return new WaitForSeconds(5);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "Fair enough.";
            yield return new WaitForSeconds(5);
        }

        crimsonNav.SetDestination(storyWaypoints[5].position);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "It's locked...";
        yield return new WaitForSeconds(5);
        
        speaking = "Dark";
        textMeshProUGUIs[0].text = "Try hacking the keypad?";
        textMeshProUGUIs[1].text = "Have any gadgets on hand?";
        textMeshProUGUIs[2].text = "";

        speechContainer.SetActive(false);
        optionsContainer.SetActive(true);

        yield return new WaitUntil(() => Input.anyKeyDown);

        optionsContainer.SetActive(false);
        speechContainer.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // Try hacking the keypad?
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "Could you try hacking that keypad there?";
            yield return new WaitForSeconds(5);

            // MOOD CHECK MOOD CHECK
            if (mood >= 0)
            {
                speaking = "Crimson";
                textMeshProUGUIs[3].text = "I'm not really one to hack, but...";
                yield return new WaitForSeconds(5);

                // Punches keypad
                
                speaking = "Crimson";
                textMeshProUGUIs[3].text = "There you go.";
                yield return new WaitForSeconds(5);

                speaking = "Dark";
                textMeshProUGUIs[3].text = "Wow... Guess that worked.";
                yield return new WaitForSeconds(5);
            }
            else
            {
                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Nope!";
                yield return new WaitForSeconds(2);

                // Kicks door in

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Opened it.";
                yield return new WaitForSeconds(5);

                speaking = "Dark";
                textMeshProUGUIs[3].text = "And probably alerted everyone here!";
                yield return new WaitForSeconds(5);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Well what can you do.";
                yield return new WaitForSeconds(5);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // Have any gadgets on hand?
        {
            speaking = "Dark";
            textMeshProUGUIs[3].text = "Got anything to get that door open with?";
            yield return new WaitForSeconds(5);

            // Kicks door in

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Yep.";
            yield return new WaitForSeconds(5);

            speaking = "Dark";
            textMeshProUGUIs[3].text = "And you probably just alerted everyone here!";
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Well what can you do.";
            yield return new WaitForSeconds(5);
        }

        speaking = "Dark";
        textMeshProUGUIs[0].text = "Head inside.";
        textMeshProUGUIs[1].text = "Head inside.";
        textMeshProUGUIs[2].text = "Head inside.";

        speechContainer.SetActive(false);
        optionsContainer.SetActive(true);

        yield return new WaitUntil(() => Input.anyKeyDown);

        optionsContainer.SetActive(false);
        speechContainer.SetActive(true);

        storyBeat = 2;
        eventEnded = true;
    }

    IEnumerator StoryBeat2()
    {
        eventEnded = false;

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Alright, head inside...";
        yield return new WaitForSeconds(5);

        crimsonNav.SetDestination(storyWaypoints[6].position);

        textMeshProUGUIs[3].text = "Is the safe already open?";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Yep.";
        yield return new WaitForSeconds(2);


        speaking = "Dark";
        textMeshProUGUIs[3].text = "And is that...";
        yield return new WaitForSeconds(5);

        // Picks up yeast jar

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Yeast? Yeah, it says \"Yeast\" in Italian on it.";
        yield return new WaitForSeconds(5);

        speaking = "Dark";
        textMeshProUGUIs[3].text = "...You were sent there to steal some YEAST?";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Yeah, whaaaat?";
        yield return new WaitForSeconds(5);

        speaking = "Dark";
        textMeshProUGUIs[3].text = "Must be some award-winning yeast.";
        yield return new WaitForSeconds(5);

        speaking = "Crimson";
        textMeshProUGUIs[3].text = "Yeah, I guess so? I should start heading out. Let's just put that here...";
        yield return new WaitForSeconds(5);

        crimsonNav.SetDestination(storyWaypoints[5].position);

        if (nameMentioned || doorKicked)
        {
            if (nameMentioned)
            {
                // Boss and guard emerge - frantic exit choices

                speaking = "Boss";
                textMeshProUGUIs[3].text = "Ann Foreign! Guards, get her!";
                yield return new WaitForSeconds(5);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Crap, I've been seen! Gotta go!";
                yield return new WaitForSeconds(5);
            }
            else if (doorKicked)
            {
                // Guards emerge - frantic exit choices

                speaking = "Dark";
                textMeshProUGUIs[3].text = "Looks like you've been seen, run for it!";
                yield return new WaitForSeconds(5);
            }

            speaking = "Dark";
            textMeshProUGUIs[0].text = "Run past him!";
            textMeshProUGUIs[1].text = "Knock him out!";
            textMeshProUGUIs[2].text = "";

            speechContainer.SetActive(false);
            optionsContainer.SetActive(true);

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2));

            optionsContainer.SetActive(false);
            speechContainer.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // Run past him!
            {
                speaking = "Dark";
                textMeshProUGUIs[3].text = "Run past him!";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // Knock him out!
            {
                speaking = "Dark";
                textMeshProUGUIs[3].text = "Knock him out!";
            }
            yield return new WaitForSeconds(5);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "Better plan!";
            yield return new WaitForSeconds(5);

            crimsonNav.SetDestination(storyWaypoints[7].position);

            speaking = "Crimson";
            textMeshProUGUIs[3].text = "OKAY";
            yield return new WaitForSeconds(2);
            textMeshProUGUIs[3].text = "MAYBE NOT BETTER PLAN!";
            yield return new WaitForSeconds(5);

            crimsonNav.SetDestination(storyWaypoints[8].position);

            speaking = "Dark";
            textMeshProUGUIs[0].text = "Watch your step!";
            textMeshProUGUIs[1].text = "Keep running!";
            textMeshProUGUIs[2].text = "";

            speechContainer.SetActive(false);
            optionsContainer.SetActive(true);

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2));

            optionsContainer.SetActive(false);
            speechContainer.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // Watch your step!
            {
                speaking = "Dark";
                textMeshProUGUIs[3].text = "Watch your step!";
                yield return new WaitForSeconds(5);

                // Nearly trips (set to close waypoint, wait 1 second, set to far waypoint?)

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "That was close, thanks!";
                yield return new WaitForSeconds(5);

                crimsonNav.SetDestination(storyWaypoints[8].position);

                // Mood check

                if (mood >= 0)
                {
                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "God, that was a lot... Still have to lose them just in case.";
                    yield return new WaitForSeconds(5);
                    textMeshProUGUIs[3].text = "Say, Dark... Do you wanna go out for a drink after all this?";
                    yield return new WaitForSeconds(5);

                    speaking = "Dark";
                    textMeshProUGUIs[0].text = "Sure.";
                    textMeshProUGUIs[1].text = "You're buying.";
                    textMeshProUGUIs[2].text = "";

                    speechContainer.SetActive(false);
                    optionsContainer.SetActive(true);

                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2));

                    optionsContainer.SetActive(false);
                    speechContainer.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // Sure. 
                    {
                        speaking = "Dark";
                        textMeshProUGUIs[3].text = "Sure. I'd... Love to.";
                        yield return new WaitForSeconds(5);

                        speaking = "Crimson";
                        textMeshProUGUIs[3].text = "Oh wow ahah! First time hearing you be that positive about something.";
                        yield return new WaitForSeconds(3);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // You're buying.
                    {
                        speaking = "Dark";
                        textMeshProUGUIs[3].text = "You're buying!";
                        yield return new WaitForSeconds(5);

                        speaking = "Crimson";
                        textMeshProUGUIs[3].text = "Ahah, alright.";
                        yield return new WaitForSeconds(3);
                    }

                    textMeshProUGUIs[3].text = "Say what, wanna share a bottle of Saint Matin?";
                    yield return new WaitForSeconds(3);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "From the people we just robbed? Okay! Might be their last, seeing as you stole their famous yeast.";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "So let's enjoy it.";
                    yield return new WaitForSeconds(5);

                    // END WIN/HAPPY
                }
                else
                {
                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "What are you gonna do with your part of the earnings?";
                    yield return new WaitForSeconds(5);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "I don't know... Might go for a nice night out at this one fancy restaurant I've been eyeing. You?";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "I was thinking the same...";
                    yield return new WaitForSeconds(3);
                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "Hope you have a good time.";
                    yield return new WaitForSeconds(3);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "Yeah... You too. See you on the next one?";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "Yeah, see you...";
                    yield return new WaitForSeconds(5);

                    // END - WIN/SAD
                }

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // Keep running!
            {
                speaking = "Dark";
                textMeshProUGUIs[3].text = "Keep running!";
                yield return new WaitForSeconds(3);

                // Trips and falls, yeast jar shatters, guards rush in

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Ow!";
                yield return new WaitForSeconds(2);

                // Mood check
                if (mood >= 0)
                {
                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "Crimson! Oh no...";
                    yield return new WaitForSeconds(3);

                    // END - JAILBREAK
                }
                else
                {
                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "Crimson...";
                    yield return new WaitForSeconds(3);

                    //END - JAIL
                }
            }


        }
        else
        {
            // Calm exit choices
            speaking = "Dark";
            textMeshProUGUIs[3].text = "Looks calm...";
            yield return new WaitForSeconds(3);

            speaking = "Dark";
            textMeshProUGUIs[0].text = "Use the fire escape.";
            textMeshProUGUIs[1].text = "Walk out the front door.";
            textMeshProUGUIs[2].text = "";

            speechContainer.SetActive(false);
            optionsContainer.SetActive(true);

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2));

            optionsContainer.SetActive(false);
            speechContainer.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // Use the fire escape.
            {
                speaking = "Dark";
                textMeshProUGUIs[3].text = "Use the fire escape, just to be safe.";
                yield return new WaitForSeconds(5);

                // Mood check
                if (mood >= 0)
                {
                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "You know what? Sure.";
                    yield return new WaitForSeconds(5);

                    crimsonNav.SetDestination(storyWaypoints[8].position);

                    textMeshProUGUIs[3].text = "A bit boring, but it's probably worth it.";
                    yield return new WaitForSeconds(5);

                    textMeshProUGUIs[3].text = "Say, Dark... Do you wanna go out for a drink after all this?";
                    yield return new WaitForSeconds(5);

                    speaking = "Dark";
                    textMeshProUGUIs[0].text = "Sure.";
                    textMeshProUGUIs[1].text = "You're buying.";
                    textMeshProUGUIs[2].text = "";

                    speechContainer.SetActive(false);
                    optionsContainer.SetActive(true);

                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2));

                    optionsContainer.SetActive(false);
                    speechContainer.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // Sure. 
                    {
                        speaking = "Dark";
                        textMeshProUGUIs[3].text = "Sure. I'd... Love to.";
                        yield return new WaitForSeconds(5);

                        speaking = "Crimson";
                        textMeshProUGUIs[3].text = "Oh wow ahah! First time hearing you be that positive about something.";
                        yield return new WaitForSeconds(3);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // You're buying.
                    {
                        speaking = "Dark";
                        textMeshProUGUIs[3].text = "You're buying!";
                        yield return new WaitForSeconds(5);

                        speaking = "Crimson";
                        textMeshProUGUIs[3].text = "Ahah, alright.";
                        yield return new WaitForSeconds(3);
                    }

                    textMeshProUGUIs[3].text = "Say what, wanna share a bottle of Saint Matin?";
                    yield return new WaitForSeconds(3);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "From the people we just robbed? Okay! Might be their last, seeing as you stole their famous yeast.";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "So let's enjoy it.";
                    yield return new WaitForSeconds(5);

                    // END WIN/HAPPY
                }
                else
                {
                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "Nah. I'd rather walk out the front. All badass-like, you know?";
                    yield return new WaitForSeconds(5);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "Whatever you say...";
                    yield return new WaitForSeconds(5);

                    crimsonNav.SetDestination(storyWaypoints[1].position);

                    speaking = "David";
                    textMeshProUGUIs[3].text = "Hey! I lost track of you when the fire alarm went off. Where'd you go?";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "Oh, yes! Of course.";
                    yield return new WaitForSeconds(3);
                    textMeshProUGUIs[3].text = "When I walked out of the bathroom I didn't see you so I asked another guard if they could show me the way to Mr. Snowmeadow.";
                    yield return new WaitForSeconds(5);
                    textMeshProUGUIs[3].text = "I didn't catch their name. Appointment went well though, Thank you!";
                    yield return new WaitForSeconds(5);

                    speaking = "David";
                    textMeshProUGUIs[3].text = "Ahh, well alright, Miss. I'll follow you to the exit, if you don't mind.";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "Of course.";
                    yield return new WaitForSeconds(3);

                    crimsonNav.SetDestination(storyWaypoints[9].position);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "What are you gonna do with your part of the earnings?";
                    yield return new WaitForSeconds(5);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "I don't know... Might go for a nice night out at this one fancy restaurant I've been eyeing. You?";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "I was thinking the same...";
                    yield return new WaitForSeconds(3);
                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "Hope you have a good time.";
                    yield return new WaitForSeconds(3);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "Yeah... You too. See you on the next one?";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "Yeah, see you...";
                    yield return new WaitForSeconds(5);

                    // END - WIN/SAD
                }
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // Walk out the front door.
            {
                speaking = "Dark";
                textMeshProUGUIs[3].text = "Walk out the front door! Try and act unsuspicious.";
                yield return new WaitForSeconds(5); 
                
                speaking = "Crimson";
                textMeshProUGUIs[3].text = "I like your style! Just what I was planning.";
                yield return new WaitForSeconds(5);

                crimsonNav.SetDestination(storyWaypoints[1].position);

                speaking = "David";
                textMeshProUGUIs[3].text = "Hey! I lost track of you when the fire alarm went off. Where'd you go?";
                yield return new WaitForSeconds(5);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Oh, yes! Of course.";
                yield return new WaitForSeconds(3);
                textMeshProUGUIs[3].text = "When I walked out of the bathroom I didn't see you so I asked another guard if they could show me the way to Mr. Snowmeadow.";
                yield return new WaitForSeconds(5);
                textMeshProUGUIs[3].text = "I didn't catch their name. Appointment went well though, Thank you!";
                yield return new WaitForSeconds(5);

                speaking = "David";
                textMeshProUGUIs[3].text = "Ahh, well alright, Miss. I'll follow you to the exit, if you don't mind.";
                yield return new WaitForSeconds(5);

                speaking = "Crimson";
                textMeshProUGUIs[3].text = "Of course.";
                yield return new WaitForSeconds(3);

                crimsonNav.SetDestination(storyWaypoints[1].position);

                // Mood check
                if (mood >= 0)
                {
                    textMeshProUGUIs[3].text = "Say, Dark... Do you wanna go out for a drink after all this?";
                    yield return new WaitForSeconds(5);

                    speaking = "Dark";
                    textMeshProUGUIs[0].text = "Sure.";
                    textMeshProUGUIs[1].text = "You're buying.";
                    textMeshProUGUIs[2].text = "";

                    speechContainer.SetActive(false);
                    optionsContainer.SetActive(true);

                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad2));

                    optionsContainer.SetActive(false);
                    speechContainer.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // Sure. 
                    {
                        speaking = "Dark";
                        textMeshProUGUIs[3].text = "Sure. I'd... Love to.";
                        yield return new WaitForSeconds(5);

                        speaking = "Crimson";
                        textMeshProUGUIs[3].text = "Oh wow ahah! First time hearing you be that positive about something.";
                        yield return new WaitForSeconds(3);
                    }
                    else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // You're buying.
                    {
                        speaking = "Dark";
                        textMeshProUGUIs[3].text = "You're buying!";
                        yield return new WaitForSeconds(5);

                        speaking = "Crimson";
                        textMeshProUGUIs[3].text = "Ahah, alright.";
                        yield return new WaitForSeconds(3);
                    }

                    textMeshProUGUIs[3].text = "Say what, wanna share a bottle of Saint Matin?";
                    yield return new WaitForSeconds(3);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "From the people we just robbed? Okay! Might be their last, seeing as you stole their famous yeast.";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "So let's enjoy it.";
                    yield return new WaitForSeconds(5);

                    // END WIN/HAPPY
                }
                else
                {
                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "What are you gonna do with your part of the earnings?";
                    yield return new WaitForSeconds(5);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "I don't know... Might go for a nice night out at this one fancy restaurant I've been eyeing. You?";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "I was thinking the same...";
                    yield return new WaitForSeconds(3);
                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "Hope you have a good time.";
                    yield return new WaitForSeconds(3);

                    speaking = "Dark";
                    textMeshProUGUIs[3].text = "Yeah... You too. See you on the next one?";
                    yield return new WaitForSeconds(5);

                    speaking = "Crimson";
                    textMeshProUGUIs[3].text = "Yeah, see you...";
                    yield return new WaitForSeconds(5);

                    // END - WIN/SAD
                }
            }
        }
    }
}


/* Code storage - commonly used code for copy/pasting

// Selecting responses after dialogue choices are made
if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) // 
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) // 
        {

        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) // 
        {

        }

// Speech template
speaking = "";
        textMeshProUGUIs[3].text = "";
        yield return new WaitForSeconds(5);

// Dialogue choices template
speaking = "Dark";
        textMeshProUGUIs[0].text = "OPTION 1";
        textMeshProUGUIs[1].text = "OPTION 2";
        textMeshProUGUIs[2].text = "OPTION 3";

        speechContainer.SetActive(false);
        optionsContainer.SetActive(true);

        yield return new WaitUntil(() => Input.anyKeyDown);

        optionsContainer.SetActive(false);
        speechContainer.SetActive(true);
*/
