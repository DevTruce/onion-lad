using UnityEngine;

public class moveController : MonoBehaviour
{

  //////////////////////////////////////////////////////////////////////////////////// VARIABLES
    private Rigidbody2D rb;
    private Animator anim;
    private float xInput;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Collision Check")]
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private  Transform groundCheck;
    [SerializeField] private  LayerMask whatIsGround;
    private  bool isGrounded;

    //////////////////////////////////////////////////////////////////////////////////// LOGIC 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        AnimationControllers();

        CollisionChecks();

        xInput = Input.GetAxisRaw("Horizontal");

        // movement 
        rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);

        // jump
        if(Input.GetKeyDown(KeyCode.Space))
          if(isGrounded) 
            rb.linearVelocity = new Vector2(rb.linearVelocity.y,  jumpForce);

    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    private void AnimationControllers()
    {
      bool isMoving = rb.linearVelocity.x != 0;
      anim.SetBool("isMoving", isMoving);
    }


    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
