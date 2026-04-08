using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource mainTheme;
    public bool playMusic = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playMusic)
        {
            mainTheme.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
