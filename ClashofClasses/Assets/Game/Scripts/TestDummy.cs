using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestDummy : MonoBehaviour
{
    public Transform player;
    Renderer changeColor;
    Color defaultColor;
    //bool spin;
    public Rigidbody rb;
    float spinForce = 2000f;
    void Start()
    {
        changeColor = GetComponent<Renderer>();
        defaultColor = changeColor.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - player.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
            transform.rotation = Quaternion.LookRotation(direction);

    }

    void OnTriggerEnter(Collider attack)
    {
        if (attack.CompareTag("Attack"))
        {
          
            StartCoroutine(FlashRed());
            
            
        }
    }

    IEnumerator FlashRed()
    {
        changeColor.material.color = Color.red;
       // spin = true;
        yield return new WaitForSeconds(0.5f);
        changeColor.material.color = defaultColor;
        //spin = false;
    }
}
