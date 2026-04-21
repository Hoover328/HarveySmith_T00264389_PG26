using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextFill : MonoBehaviour
{
    public NpcBody Npc;
    public NpcBody Npc2;
    public OutDoorTalking OutDoorTalking;
    private Coroutine shakeText;
    private Coroutine shakeText2;
    internal int dialougeCheck = 0;
    public int dialougeCheck2 = 1;
    public bool fireOnce = true;
    public bool fireOnce2 = true;
    public TMPro.TextMeshProUGUI dialogueText;
    public TMPro.TextMeshProUGUI dialogueText2;
    public float textSpeed = 0.5f;
    public Fade fade;
    private bool  canSkip;
    public GameObject Npc1;
    public GameObject Cat;
    public Door door;
    public bool goodEnd = false;
    public AudioSource meow;
    public AudioSource mainTheme;
    public AudioSource secret;
    public AudioSource heal;
    public AudioSource stab;
    public bool finalState = false;
    public bool avoldBeaten = false;
    public Image endScreen;
    public Image deadAvold;
    public TextMeshProUGUI endText;
    public Fade fade2;
    public int index = 0;
    internal string[] dialouge = { "Hello... Ive been waiting for you to come back.", 
        "You dont have any weapon in your possesion, correct?", "Meet me in the room behind me... You can take whichever sword you want, free of charge of course..." };


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (endScreen != null)
        {
            endScreen.enabled = false;
        }
        if (deadAvold != null)
        {
            deadAvold.enabled = false;
        }

        if (endText != null)
        {
            endText.enabled = false;
        }

        if (Npc2 == null)
        {             
            return;
        }

           if (dialogueText2 == null)
            {
                return;
        }

           if(Cat == null) { return; }

           if (door == null) { return; }
           if (meow == null) { return; }
              if (heal == null) { return; }
                if (secret == null) { return; }
                if(stab == null) { return; }
                if (endScreen == null) { return; }
                if (deadAvold == null) { return; }
                if (endText == null) { return; }
                if (fade2 == null) { return; };
    }

    // Update is called once per frame
    void Update()
    {
        if (avoldBeaten)
        {
            dialougeCheck = 21;
            
        }
        //Debug.Log(dialougeCheck);
        if (Npc != null)
        {
            if (Npc.talking)
            {
                if (fireOnce)
                {

                    fireOnce = false;
                    StartCoroutine(TextAnimation(dialouge[dialougeCheck], dialogueText));

                    /* 
                     
                     
                    else if (dialougeCheck == 5)
                    {
                        StartCoroutine(TextAnimation("Well..? Which sword would you like?", dialogueText));

                    }

                    else if (dialougeCheck == 8)
                    {
                        StartCoroutine(TextAnimation("Now then... Take that sword, and enter the temple. If you can make it to the end, you might find something interesting...", dialogueText));

                    }

                    else if (dialougeCheck == 10)
                    {
                        StartCoroutine(TextAnimation("What are you waiting for...", dialogueText));

                    }

                    else if (dialougeCheck == 12)
                    {
                        StartCoroutine(TextAnimation("I understand... You are confused...", dialogueText));

                    }

                    else if (dialougeCheck == 13)
                    {
                        StartCoroutine(TextAnimation("Ill escort you out... This place is not safe anymore...", dialogueText));

                    }

                    else if (dialougeCheck == 14)
                    {
                        OutDoorTalking.readyToKill = false;
                        StartCoroutine(TextAnimation("You do trust me right..? The exit is a short distance behind you... Lets go...", dialogueText));

                    }

                    else if (dialougeCheck == 16)
                    {
                        OutDoorTalking.readyToKill = false;
                        StartCoroutine(TextAnimation("...", dialogueText));

                    }

                    else if (dialougeCheck == 17)
                    {
                        OutDoorTalking.readyToKill = false;
                        secret.Play();
                        StartCoroutine(TextAnimation("What..? You dont do you? I thought that might happen.", dialogueText));

                    }

                    else if (dialougeCheck == 18)
                    {
                        OutDoorTalking.readyToKill = false;
                        StartCoroutine(TextAnimation("Tell me... Did he warn you?", dialogueText));

                    }

                    else if (dialougeCheck == 19)
                    {
                        OutDoorTalking.readyToKill = false;
                        StartCoroutine(TextAnimation("Very well then... Its time.", dialogueText));

                    }

                    else if (dialougeCheck == 21)
                    {
                        OutDoorTalking.readyToKill = false;
                        StartCoroutine(TextAnimation("You are... Strong... but im not finished...", dialogueText));

                    }

                    else if (dialougeCheck == 22)
                    {
                        OutDoorTalking.readyToKill = false;
                        StartCoroutine(killAvold());
                        StartCoroutine(TextAnimation("Its time for us to end this", dialogueText));

                    }

                    else if (dialougeCheck == 30)
                    {
                        StartCoroutine(TextAnimation("I would turn back if I were you. But if you really wont, ill teach you how to survive!", dialogueText));
                    }

                    else if (dialougeCheck == 31)
                    {
                        StartCoroutine(TextAnimation("Use WASD to move those legs of yours, thats pretty important...", dialogueText));
                    }

                    else if (dialougeCheck == 32)
                    {
                        StartCoroutine(TextAnimation("Use SPACE to jump, and SHIFT to give yourself a boost in the direction youre moving", dialogueText));
                    }

                    else if (dialougeCheck == 33)
                    {
                        StartCoroutine(TextAnimation("Oh... And if you get your hands on a weapon, use LEFTCLICK to attack", dialogueText));
                    }

                    else if (dialougeCheck == 34)
                    {
                        StartCoroutine(TextAnimation("Thats all... Now get out of here!", dialogueText));
                    }*/
                }


                if (Mouse.current.leftButton.wasPressedThisFrame && !canSkip && !fade.lockInputs)
                {
                 
                   
                    dialougeCheck++;
                    fireOnce = true;
                   /* if (dialougeCheck == 1)
                    {
                        dialougeCheck = 2;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 2)
                    {
                        dialougeCheck = 3;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 3)
                    {
                        dialougeCheck = 4;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 5)
                    {
                        dialougeCheck = 6;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 8)
                    {
                        dialougeCheck = 9;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 10)
                    {
                        dialougeCheck = 11;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 12)
                    {
                        dialougeCheck = 13;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 13)
                    {
                        dialougeCheck = 14;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 14 && !goodEnd)
                    {
                        dialougeCheck = 15;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 14 && goodEnd)
                    {
                        dialougeCheck = 16;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 16)
                    {
                        dialougeCheck = 17;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 17)
                    {
                        dialougeCheck = 18;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 18)
                    {
                        dialougeCheck = 19;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 19)
                    {
                        dialougeCheck = 20;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 21)
                    {
                        dialougeCheck = 22;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 30)
                    {
                        dialougeCheck = 31;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 31)
                    {
                        dialougeCheck = 32;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 32)
                    {
                        dialougeCheck = 33;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 33)
                    {
                        dialougeCheck = 34;
                        fireOnce = true;
                    }

                    else if (dialougeCheck == 34)
                    {
                        dialougeCheck = 35;
                        fireOnce = true;
                    }*/




                }
            }
        }

        if (Npc2 != null)
        {
            if (Npc2.talking)
            {
                if (fireOnce2)
                {

                    fireOnce2 = false;

                    if (door.doorOpen && !goodEnd && dialougeCheck2 == 1 || door.doorOpen && !goodEnd && dialougeCheck2 == 4)
                    {
                        StartCoroutine(TextAnimation("Meow~ *The cat points a paw in the direction you came from, almost like he is telling you to go back where you came*", dialogueText2));
                        finalState = true;
                        meow.Play();

                    }

                    else if (door.doorOpen && goodEnd && dialougeCheck2 == 1 || door.doorOpen && goodEnd && dialougeCheck2 == 4)
                    {
                        StartCoroutine(TextAnimation("Return to Avold, he will be waiting for you. You must destroy him, he cannot be trusted. Do not believe anything he says or does.", dialogueText2));
                        finalState = true;
                        secret.Play();

                    }

                    else if (dialougeCheck2 == 1)
                    {
                        StartCoroutine(TextAnimation("Meow~", dialogueText2));
                        meow.Play();

                    }

                    else if (dialougeCheck2 == 4)
                    {
                        goodEnd = true;
                        StartCoroutine(TextAnimation("Do not trust him. You know what will happen.", dialogueText2));
                        secret.Play();
                    }

                    else if (dialougeCheck2 == 7)
                    {
                        StartCoroutine(TextAnimation("Meow~ *You feel healthier than before*", dialogueText2));
                        heal.Play();
                    }

                    else if (dialougeCheck2 == 9)
                    {
                        StartCoroutine(TextAnimation("Ive healed your wounds. Continue through that hole and finish this.", dialogueText2));
                        heal.Play();
                    }
                }

                if (Mouse.current.leftButton.wasPressedThisFrame && !canSkip && !fade.lockInputs)
                {
                    if (dialougeCheck2 == 4)
                    {
                        StopCoroutine(shakeText2);
                        dialougeCheck2 = 5;
                        fireOnce2 = true;
                    }

                    else if (door.doorOpen && !goodEnd && dialougeCheck2 == 1 || door.doorOpen && !goodEnd && dialougeCheck2 == 4)
                    {
                        dialougeCheck2 = 6;
                        fireOnce2 = true;
                    }

                    else if (door.doorOpen && goodEnd && dialougeCheck2 == 1 || door.doorOpen && goodEnd && dialougeCheck2 == 4)
                    {
                        dialougeCheck2 = 8;
                        fireOnce2 = true;
                    }

                    if (dialougeCheck2 == 1)
                    {
                        if (UnityEngine.Random.value <= 0.2f)
                        {
                            dialougeCheck2 = 3;
                            fireOnce2 = true;
                        }
                        else
                        {
                            dialougeCheck2 = 2;
                            fireOnce2 = true;
                        }
                    }

                    else if (dialougeCheck2 == 7)
                    {
                        dialougeCheck2 = 6;
                        fireOnce2 = true;
                    }


                    else if (dialougeCheck2 == 9)
                    {
                        dialougeCheck2 = 10;
                        fireOnce2 = true;
                    }
                }

            }
        }

        if (Npc != null)
        {
            if (!Npc.talking)
            {
                fireOnce = true;
                if (shakeText != null)
                {
                    StopCoroutine(shakeText);
                    shakeText = null;
                }
                dialogueText.text = "";
            }
        }
        if (Npc2 != null)
        {
            if (!Npc2.talking)
            {
                fireOnce2 = true;
                if (shakeText2 != null)
                {
                    StopCoroutine(shakeText2);
                    shakeText2 = null;
                }
                dialogueText2.text = "";
            }
        }
    }
            IEnumerator TextAnimation(string text, TMPro.TextMeshProUGUI speaking)
            {

                 dialogueText.text = "";
                 dialogueText2.text = "";

               
                 while (fade.lockInputs)
                 {
                     yield return null;
                 }
     
               
               if (dialougeCheck == 0 && shakeText == null)
                {
                   // yield return new WaitForSeconds(fade.fadeDelay + 1f);
                    shakeText = StartCoroutine(ShakeText(dialogueText));
                }

                if (dialougeCheck == 10 && shakeText == null)
                {
                    // yield return new WaitForSeconds(fade.fadeDelay + 1f);
                    shakeText = StartCoroutine(ShakeText(dialogueText));
                }

                if (dialougeCheck2 == 4 && shakeText2 == null && !door.doorOpen)
                {
                   // yield return new WaitForSeconds(fade.fadeDelay);
                    shakeText2 = StartCoroutine(ShakeText(dialogueText2));
                }

                if (dialougeCheck == 1 && shakeText != null)
                {
                    StopCoroutine(shakeText);
                    shakeText = null; 
                }


                 /*if (dialougeCheck == 1 && shakeText != null)
                {
                    StopCoroutine(shakeText);
                    shakeText = null;

                 }*/

        
                canSkip = true;
                foreach (char character in text)
                {
                       speaking.text += character;
                    yield return new WaitForSeconds(textSpeed);
                }
                canSkip = false;

            }

            IEnumerator ShakeText(TMPro.TextMeshProUGUI speaking)
            {
                while (true)
                {
                    speaking.ForceMeshUpdate();
                    TMP_TextInfo textInfo = speaking.textInfo;

                    for (int i = 0; i < textInfo.characterCount; i++)
                    {
                    if (!textInfo.characterInfo[i].isVisible)
                        {
                            continue;
                        }

                        int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
                        int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                        Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

                        Vector3 offset = new Vector3(UnityEngine.Random.Range(-1f, 1f),UnityEngine.Random.Range(-1f, 1f), 0);

                        vertices[vertexIndex + 0] += offset;
                        vertices[vertexIndex + 1] += offset;
                        vertices[vertexIndex + 2] += offset;
                        vertices[vertexIndex + 3] += offset;
                    }


                    for (int i = 0; i < textInfo.meshInfo.Length; i++)
                    {
                        textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
                        speaking.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
                    }


                    yield return new WaitForSeconds(0.03f);
                }

            }

            IEnumerator killAvold()
            {
                yield return new WaitForSeconds(0.6f);
                endScreen.enabled = true;
                stab.Play();
                mainTheme.Stop();
                yield return new WaitForSeconds(4f);
                StartCoroutine(fade2.FadeInOut());
                yield return new WaitForSeconds(1f);
                deadAvold.enabled = true;
                yield return new WaitForSeconds(10f);
                endText.enabled = true;

            }
        }

    

