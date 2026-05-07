using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TextFill : MonoBehaviour
{
    public NpcBody Npc;
    public NpcBody Npc2;
    public NpcBody Npc3;
    public OutDoorTalking OutDoorTalking;
    private Coroutine shakeText;
    private Coroutine shakeText2;
    internal int dialougeCheck = 0;
    public int dialougeCheck2 = 0;
    public int dialougeCheck3 = 0;
    private int catRandom = 0;
    private int goodEndText = 1;
    public bool fireOnce = true;
    public bool fireOnce2 = true;
    public bool fireOnce3 = true;
    public TMPro.TextMeshProUGUI dialogueText;
    public TMPro.TextMeshProUGUI dialogueText2;
    public TMPro.TextMeshProUGUI dialogueText3;
    public float textSpeed = 0.5f;
    public Fade fade;
    public bool canSkip;
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
    private int avoldDeath = 16;
    public int index = 0;
    private int[] shakeDialouges = {0, 10, 13};
    private int secretSoundIndex = 12;
    private Coroutine shakyText;
    private bool startShake = false;


    internal string[] dialouge1 = { "Hello... Ive been waiting for you to come back.",
        "You dont have any weapon in your possesion, correct?", "Meet me in the room behind me... You can take whichever sword you want, free of charge of course...",
        "Well..? Which sword would you like?", "", "", "Now then... Take that sword, and enter the temple. If you can make it to the end, you might find something interesting...",
    "Well..? What are you waiting for..?", "I understand... You are confused...", "Ill escort you out... This place is not safe anymore...", "You do trust me right..? The exit is a short distance behind you... Lets go...",
        "...", "What..? You dont do you? I thought that might happen.", "Tell me... Did he warn you?",
        "Very well then... Its time.", "You are... Strong... but im not finished...", "Its about time for us to finally end this"};

    internal string[] dialouge2 = { "I would turn back if I were you. But if you really wont, ill teach you how to survive!",
        "Use WASD to move those legs of yours, thats pretty important...", "Use SPACE to jump, and SHIFT to give yourself a boost in the direction youre moving",
        "Oh... And if you get your hands on a weapon, use LEFTCLICK to attack", "Thats all... Now get out of here!" };

    internal string[] dialouge3 = { "Meow~", "Do not trust him. You know what will happen." };

    internal string[] dialouge4 = { "Meow ~ *The cat points a paw in the direction you came from, almost like he is telling you to go back where you came*",
        "Meow~ *You feel healthier than before*" };

    internal string[] dialouge5 = { "Return to Avold, he will be waiting for you. You must destroy him, he cannot be trusted.Do not believe anything he says or does.",
        "Ive healed your wounds. Continue through that hole and finish this."  };






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
    }

    // Update is called once per frame
    void Update()
    {

        if (avoldDeath == dialougeCheck)
        {
            StartCoroutine(killAvold());
            avoldDeath--;
        }

        if (dialougeCheck == secretSoundIndex)
        {
            if (fireOnce)
            {
                secret.Play();
            }
        }

        if (Npc != null)
        {
            if (Npc.talking)
            {
                if (fireOnce)
                {
                    fireOnce = false;
                    StartCoroutine(TextAnimation(dialouge1[dialougeCheck], dialogueText));
                }


                if (Mouse.current.leftButton.wasPressedThisFrame && !canSkip && !fade.lockInputs)
                {
                    dialougeCheck++;
                    fireOnce = true;
                }
            }
        }

        if (Npc2 != null)
        {
            if (Npc2.talking)
            {

                if (door.doorOpen)
                {
                    finalState = true;
                }

                if (!finalState)
                {

                    catRandom = 0;

                    if (UnityEngine.Random.value <= 0.2f)
                    {
                        catRandom = goodEndText;
                        goodEnd = true;
                    }

                    if (fireOnce2)
                    {
                        fireOnce2 = false;
                        StartCoroutine(TextAnimation(dialouge3[catRandom], dialogueText2));
                        if (catRandom == goodEndText)
                        {
                            secret.Play();
                        }
                        else
                        {
                            meow.Play();
                        }
                    }

                    if (Mouse.current.leftButton.wasPressedThisFrame && !canSkip && !fade.lockInputs)
                    {
                        fireOnce = true;
                    }
                }

                else if (finalState && !goodEnd)
                {

                    if (fireOnce2)
                    {
                        fireOnce2 = false;
                        StartCoroutine(TextAnimation(dialouge4[dialougeCheck2], dialogueText2));
                    }

                    if (Mouse.current.leftButton.wasPressedThisFrame)
                    {
                        dialougeCheck2++;
                        fireOnce = true;
                    }
                }

                else if (finalState && goodEnd)
                {

                    if (fireOnce2)
                    {
                        fireOnce2 = false;
                        StartCoroutine(TextAnimation(dialouge5[dialougeCheck2], dialogueText2));
                    }

                    if (Mouse.current.leftButton.wasPressedThisFrame)
                    {
                        dialougeCheck2++;
                        fireOnce = true;
                    }
                }
            }
        }

        if (Npc3 != null)
        {
            if (Npc3.talking)
            {
                if (fireOnce3)
                {
                    fireOnce3 = false;
                    StartCoroutine(TextAnimation(dialouge2[dialougeCheck3], dialogueText3));
                }


                if (Mouse.current.leftButton.wasPressedThisFrame && !canSkip && !fade.lockInputs)
                {
                    dialougeCheck3++;
                    fireOnce3 = true;
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

        if (Npc3 != null)
        {
            if (!Npc3.talking)
            {
                fireOnce3 = true;
                dialogueText3.text = "";
            }
        }
    }

    IEnumerator TextAnimation(string text, TMPro.TextMeshProUGUI speaking)
    {
        if (Npc != null)
        {
            if (Npc.talking)
            {
                startShake = false;

                foreach (var items in shakeDialouges)
                {
                    if (dialougeCheck == items)
                    {
                        startShake = true;
                        break;
                    }
                }


                if (startShake)
                {
                    shakyText = StartCoroutine(ShakeText(speaking));
                }
                else
                {
                    if (shakyText != null)
                    {
                        StopCoroutine(shakyText);
                    }
                }
            }
        }

        if (dialogueText != null)
        {
            dialogueText.text = "";
        }
        if (dialogueText2 != null)
        {
            dialogueText2.text = "";
        }
        if (dialogueText3 != null)
        {
            dialogueText3.text = "";
        }

        while (fade.lockInputs)
        {
            yield return null;
        }

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

                Vector3 offset = new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f), 0);

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
        
    

    

