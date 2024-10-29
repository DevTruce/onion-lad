using UnityEngine;

public class moveController : MonoBehaviour
{

  //////////////////////////////////////////////////////////////////////////////////// VARIABLES
    private Rigidbody2D rb;
    private Animator anim;
    private bool faceingRight = true;
    private float xInput;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Header("Collision Check")]
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private  Transform groundCheck;
    [SerializeField] private  LayerMask whatIsGround;
    private  bool isGrounded;

    //////////////////////////////////////////////////////////////////////////////////// GAME STATES

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        AnimationControllers();
        CollisionChecks();
        FlipController();

        xInput = Input.GetAxisRaw("Horizontal");

        Movement();

        if(Input.GetKeyDown(KeyCode.Space))
          Jump();
    }

    //////////////////////////////////////////////////////////////////////////////////// LOGIC

    private void CollisionChecks()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
 
    private void AnimationControllers()
    {
      anim.SetFloat("xVelocity", rb.linearVelocityX);
      anim.SetFloat("yVelocity", rb.linearVelocityY);
      anim.SetBool("isGrounded", isGrounded);
    }

    private void FlipController() {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

      //// Flip on character move 
      // if(rb.linearVelocity.x < 0 && faceingRight) 
      //   Flip();
      // else if(rb.linearVelocity.x > 0 && !faceingRight) 
      //   Flip();

      //// Flip on mouse move
      if(mousePos.x < transform.position.x && faceingRight) 
        Flip();
      else if(mousePos.x > transform.position.x && !faceingRight) 
        Flip();
    }

    private void Flip()
    {
      faceingRight = !faceingRight; // works as a switcher
      transform.Rotate(0,180,0);
    }

    private void Jump() 
    {
      if(isGrounded) 
        rb.linearVelocity = new Vector2(rb.linearVelocity.y,  jumpForce);
    }

    private void Movement() 
    {
      rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocity.y);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
