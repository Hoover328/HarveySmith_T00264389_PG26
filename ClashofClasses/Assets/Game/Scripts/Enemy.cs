using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.position - player.position;
        direction.y = 0f; 

        if (direction.sqrMagnitude > 0.001f)
            transform.rotation = Quaternion.LookRotation(direction);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Attack"))
        {
            Destroy(gameObject);
        }
    }
}
