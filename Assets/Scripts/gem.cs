using UnityEngine;

public class gem : MonoBehaviour
{
    public Player mPlayer;
    public GameObject objGemEffcts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            mPlayer.addPoint();
            Instantiate(objGemEffcts , gameObject.transform.position , gameObject.transform.rotation);

            Destroy(gameObject, 0.1f);
        }
    }
}
