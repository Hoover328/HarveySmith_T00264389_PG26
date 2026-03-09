using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TextFill : MonoBehaviour
{
    public NpcBody Npc;
    private Coroutine shakeText;
    public int dialougeCheck = 1;
    bool fireOnce = true;
    public TMPro.TextMeshProUGUI dialogueText;  
    public float textSpeed = 0.5f;
    public Fade fade;
    private bool  canSkip;
    public GameObject Avold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Npc.talking)
        {
            if (fireOnce)
            {

                fireOnce = false;

                if (dialougeCheck == 1)
                {
                    StartCoroutine(TextAnimation("Hello... Ive been waiting for you to come back."));
                }

                else if (dialougeCheck == 2)
                {
                    StartCoroutine(TextAnimation("You dont have any weapon in your possesion, correct?"));
                    Avold.transform.position = new Vector3 (13.14f, 1.287f, 40.44f);

                }

                else if (dialougeCheck == 3)
                {
                    StartCoroutine(TextAnimation("Meet me in the room behind me... " +
                        "You can take whichever sword you want, free of charge of course..."));

                }

            }
                if (Mouse.current.leftButton.wasPressedThisFrame && !canSkip)
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
                    dialougeCheck = 0;
                    fireOnce = true;
                }




                }
           /* if (Mouse.current.leftButton.wasPressedThisFrame && !canSkip)
            {
                if (dialougeCheck == 1)
                {
                    dialogueText.text = "Hello... Ive been waiting for you to come back.";
                }

                else if (dialougeCheck == 2)
                {
                    dialogueText.text = "You dont have any weapon in your possesion, correct?";
                }

                else if (dialougeCheck == 3)
                {
                    dialogueText.text = "Follow me.. " +
                        "You can take whichever sword you want, free of charge of course...";
                }
            }*/


                if (!Npc.talking)
            {
                fireOnce = true;
                dialogueText.text = "";
            }

            IEnumerator TextAnimation(string text)
            {
                
                dialogueText.text = "";
                if (dialougeCheck == 1 && shakeText == null)
                {
                    yield return new WaitForSeconds(fade.fadeDelay + 1f);
                    shakeText = StartCoroutine(ShakeText());
                }

                if (dialougeCheck == 2 && shakeText != null)
                {
                    StopCoroutine(shakeText);
                }

        
                canSkip = true;
                foreach (char character in text)
                {
                    dialogueText.text += character;
                    yield return new WaitForSeconds(textSpeed);
                }
                canSkip = false;

            }

            IEnumerator ShakeText()
            {
                while (true)
                {
                    dialogueText.ForceMeshUpdate();
                    TMP_TextInfo textInfo = dialogueText.textInfo;

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
                        dialogueText.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
                    }


                    yield return new WaitForSeconds(0.03f);
                }

            }
        }
    }
}
