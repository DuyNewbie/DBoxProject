using UnityEngine;

public class arrow : MonoBehaviour
{
    public Vector3 huongX = Vector3.right;

    private void Start()
    {
        Destroy(gameObject , 0.15f);
    }
    void Update()
    {
        transform.Translate(Vector2.up * 17 * Time.deltaTime);
    }
}
