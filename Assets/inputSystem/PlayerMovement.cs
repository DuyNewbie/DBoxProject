using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayeController playcontroller;

    public float moveSpeed = 5;
    public Rigidbody2D playerRB;
    public Transform groundCheck;
    public Transform wallCheck;
    public Animator animator;
    public LayerMask groundLayer;

    float direction = 0;
    float jumpForce = 10;
    bool isGround = true;
    bool isWall = false;
    Vector2 vCheckWall = new Vector2(0.1f , 1.3f);
    Vector2 vCheckGround = new Vector2(0.98f, 0.1f);

    private void Awake()
    {
        playcontroller = new PlayeController();
        playcontroller.Enable();

        playcontroller.Land.move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        playcontroller.Land.jump.performed += ctx => jump();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(wallCheck.position, vCheckWall);
    }

    void FixedUpdate()
    {
        isGround = Physics2D.OverlapBox(groundCheck.position, vCheckGround , 0f , groundLayer);
        isWall = Physics2D.OverlapBox(wallCheck.position, vCheckWall , 0f, groundLayer);
        
        if(direction > 0) transform.localScale = new Vector3(1 , 1, 1);
        else if(direction < 0) transform.localScale = new Vector3(-1 , 1, 1);
        
        if (direction > 0 || direction < 0) animator.SetBool("isRun", true);
        else animator.SetBool("isRun", false);

        if(isGround) animator.SetBool("isJump" , false);
        else animator.SetBool("isJump" , true);

        if (isWall) return;

        playerRB.velocity = new Vector2(direction * moveSpeed, playerRB.velocity.y);

    }

    void jump()
    {
        if (!isGround || !playerRB) return;

        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
    }
}
