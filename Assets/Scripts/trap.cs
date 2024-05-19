using UnityEngine;

public class trap : MonoBehaviour
{
    private float timer = 1;
    private bool isCollider = false;
    public Player mPlayer;
    public int damage = 0;

    private void FixedUpdate()
    {
        if (!isCollider) return;

        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            timer = 1;
            minusHealthPlayer();
        }
    }

    void minusHealthPlayer()
    {
        mPlayer.minusHealth(damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            minusHealthPlayer();
            isCollider = true;
            timer = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollider = false;
            timer = 1;
        }
    }

}
