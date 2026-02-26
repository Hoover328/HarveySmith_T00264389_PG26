using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 3f;
    private Vector3 direction;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
        
    }

   
}
