using UnityEngine;

public class mod1 : MonoBehaviour
{
    public Player mPlayer;
    public LayerMask layerPlayer;
    public Animator animator;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float xHuong = 0;
    private float speed = 3;
    private bool isHit = false;
    private Vector2 topPointion;
    private bool isTarget = false;
    private bool isAttack = false;
    private float timeAttack = 0.9f;
    private bool isDie = false;

    public GameObject arrow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = rb.GetComponent<BoxCollider2D>();
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(transform.position.x + 0.077278f, transform.position.y + 1.25f), new Vector2(0.4f, 0.1298275f));
    }

    // Update is called once per frame
    void Update()
    {

        if (isDie)
        {
            speed = 0;
            isAttack = false;
            isTarget = false;
            animator.SetBool("isHit", true);
            animator.SetBool("isRun", false);
            animator.SetBool("isAttack", false);

            return;
        }

        topPointion = new Vector2(transform.position.x + 0.077278f, transform.position.y + 1.25f);

        isHit = Physics2D.OverlapBox(topPointion, new Vector2(0.4f, 0.1298275f), 0f , layerPlayer);

        if (isHit)
        {

            isDie = true;
            modDie();
        }


        if (isAttack)
        {
            timeAttack -= Time.deltaTime;
            speed = 0;
            if (timeAttack < 0)
            {
                timeAttack = 1f;
                isAttack = false;

                Instantiate(arrow, new Vector2(transform.position.x + 0.077278f, transform.position.y + 0.35f), Quaternion.Euler(0, 0, 90 * -xHuong));
            }

            return;
        }


        if (mPlayer.transform.position.x - gameObject.transform.position.x > 0)
        {
            xHuong = 1;
            transform.localScale = new Vector3 (-1, 1, 1);
        }
        else
        {
            xHuong = -1;
            transform.localScale = new Vector3(1, 1, 1);
        }

        if(!isTarget)
        {
            speed = 0;
        }
        else
        {
            speed = 3;
        }


        if (rb == null) return;
        rb.velocity = new Vector2(xHuong * speed, rb.velocity.y);

        RaycastHit2D rayTarget = Physics2D.Raycast(gameObject.transform.position + new Vector3(0.3f,0), (mPlayer.transform.position - gameObject.transform.position), 6f, layerPlayer);

        if (rayTarget)
        {
            if (rayTarget.collider.gameObject.CompareTag("Player"))
            {
                isTarget = true;
                animator.SetBool("isRun", true);
            }

        }
        else
        {
            isTarget = false;
            animator.SetBool("isRun", false);
            animator.SetBool("isAttack", false);
        }

        RaycastHit2D rayAttack = Physics2D.Raycast(gameObject.transform.position + new Vector3(0.3f, 0), (mPlayer.transform.position - gameObject.transform.position), 3f, layerPlayer);

        if (rayAttack)
        {
            if (rayTarget.collider.gameObject.CompareTag("Player"))
            {
                isAttack = true;
                isTarget = false;
                animator.SetBool("isRun", false);
                animator.SetBool("isAttack", true);
                speed = 0;
            }

        }
        else
        {
            isAttack = false;
            animator.SetBool("isAttack", false);
        }
        

    }

    void modDie()
    {
        if (rb == null) return;
        rb.velocity = Vector3.up * 4;
        boxCollider.enabled = false;
        boxCollider.isTrigger = true;
    }
}
