using UnityEngine;

public class AvoldKill : MonoBehaviour
{
    public OutDoorTalking outDoorTalking;
    public AudioSource stab;
    public bool forceKill = false;
    public bool fireOnce = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible()
    {
        if (fireOnce)
        {
            if (outDoorTalking.readyToKill || forceKill)
            {
                stab.Play();
                fireOnce = false;
            }
        }

    }
}
