using UnityEngine;

public class baseMove : MonoBehaviour
{
    private float timeR = 1.3f;
    public float baseSpeed;
    
    void Start()
    {
       
    }

    void Update()
    {
        if (timeR < 0)
        {
            timeR = 2;
            baseSpeed = -baseSpeed;
        }
        timeR -= Time.deltaTime;
        transform.position = new Vector2(transform.position.x + baseSpeed * Time.deltaTime, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
