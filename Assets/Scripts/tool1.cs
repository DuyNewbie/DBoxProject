using UnityEngine;

public class tool1 : MonoBehaviour
{
    public Animator animator;
    public float jumpForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isPush", true);
            Rigidbody2D collisionRB = collision.GetComponent<Rigidbody2D>();
            if (collisionRB == null) return;
            collisionRB.velocity = new Vector2(collisionRB.velocity.x, jumpForce);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            animator.SetBool("isPush", false);
        }
    }
}
