using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextFill : MonoBehaviour
{
    public NpcBody Npc;
    public NpcBody Npc2;
    private Coroutine shakeText;
    private Coroutine shakeText2;
    public int dialougeCheck = 1;
    public int dialougeCheck2 = 1;
    public bool fireOnce = true;
    public bool fireOnce2 = true;
    public TMPro.TextMeshProUGUI dialogueText;
    public TMPro.TextMeshProUGUI dialogueText2;
    public float textSpeed = 0.5f;
    public Fade fade;
    private bool  canSkip;
    public GameObject Avold;
    public GameObject Cat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //  Debug.Log(dialougeCheck);
        if (Npc.talking)
        {
            if (fireOnce)
            {

                fireOnce = false;

                if (dialougeCheck == 1)
                {
                    StartCoroutine(TextAnimation("Hello... Ive been waiting for you to come back.", dialogueText));
                }

                else if (dialougeCheck == 2)
                {
                    StartCoroutine(TextAnimation("You dont have any weapon in your possesion, correct?", dialogueText));
                    Avold.transform.position = new Vector3(13.14f, 1.287f, 40.44f);

                }

                else if (dialougeCheck == 3)
                {
                    StartCoroutine(TextAnimation("Meet me in the room behind me... " +
                        "You can take whichever sword you want, free of charge of course...", dialogueText));

                }

                else if (dialougeCheck == 5)
                {
                    StartCoroutine(TextAnimation("Well..? Which sword would you like?", dialogueText));

                }

                else if (dialougeCheck == 8)
                {
                    StartCoroutine(TextAnimation("Now then... Take that sword, and enter the temple. If you can make it to the end, you might find something interesting...", dialogueText));

                }

            }

            
            if (Mouse.current.leftButton.wasPressedThisFrame && !canSkip && !fade.lockInputs)
            {
                if (dialougeCheck == 1)
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




            }
        }

        if (Npc2.talking)
        {
            if (fireOnce2)
            {

                fireOnce2 = false;

                if (dialougeCheck2 == 1)
                {
                    StartCoroutine(TextAnimation("Meow~", dialogueText2));
                }

                if (dialougeCheck2 == 4)
                {
                    StartCoroutine(TextAnimation("Do not trust him. You know what will happen.", dialogueText2));
                }
            }

            if (Mouse.current.leftButton.wasPressedThisFrame && !canSkip && !fade.lockInputs)
            {
                if (Random.value <= 0.2f) 
                {
                    dialougeCheck2 = 3;
                    fireOnce2 = true;
                }
                else
                {
                    dialougeCheck2 = 2;
                    fireOnce2 = true;
                }

                if (dialougeCheck2 == 4) 
                {
                    StopCoroutine(shakeText2);
                    dialougeCheck2 = 5;
                    fireOnce2 = true;
                }

                
            }
            }

        if (!Npc.talking)
        {
            fireOnce = true;
            dialogueText.text = "";
        }

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
            IEnumerator TextAnimation(string text, TMPro.TextMeshProUGUI speaking)
            {

                 speaking.text = "";

               
                 while (fade.lockInputs)
                 {
                     yield return null;
                 }
     
               
               if (dialougeCheck == 1 && shakeText == null)
                {
                   // yield return new WaitForSeconds(fade.fadeDelay + 1f);
                    shakeText = StartCoroutine(ShakeText(dialogueText));
                }

                if (dialougeCheck2 == 4 && shakeText2 == null)
                {
                   // yield return new WaitForSeconds(fade.fadeDelay);
                    shakeText2 = StartCoroutine(ShakeText(dialogueText2));
                }

                if (dialougeCheck == 2 && shakeText != null)
                {
                    StopCoroutine(shakeText);
                    shakeText = null; 
                }


                 if (dialougeCheck == 1 && shakeText != null)
                {
                    StopCoroutine(shakeText);
                    shakeText = null;

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
                            continue;

                        int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
                        int vertexIndex = textInfo.characterInfo[i].vertexIndex;

                        Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

                        Vector3 offset = new Vector3(
                            Random.Range(-1f, 1f),
                            Random.Range(-1f, 1f),
                            0
                        );

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
        }
    

