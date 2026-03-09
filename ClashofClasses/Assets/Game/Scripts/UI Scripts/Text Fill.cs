using System.Collections;
using UnityEngine;

public class TextFill : MonoBehaviour
{
    public NpcBody Npc;
    int dialougeCheck = 1;
    string dialougeText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Npc.talking)
        {
            if (dialougeCheck == 1)
            {
                dialougeText = "Praise be it works";
            }
        }
    }

    IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
