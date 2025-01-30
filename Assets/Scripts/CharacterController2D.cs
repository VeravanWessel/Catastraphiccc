using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 400f;
    [SerializeField] private float movementSmoothing = 0.05f;

    [Header("Ground Detection")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;

    [Header("References")]
    public GameObject GameobjectCat;
    public Animator animator;

    private Rigidbody2D rb;
    private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;
    private bool grounded;
    private bool wasGrounded;

    public UnityEvent OnLandEvent;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
    }

    private void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetKeyDown(KeyCode.Space);

        Move(move, jump);

        // **Animatie-updates**
        if (move == 0){
            animator.SetBool("Walk", false);
        }
        else { animator.SetBool("Walk", true); }
      
    }

    private void CheckGrounded()
    {
        wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.2f, whatIsGround);
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject != gameObject)
            {
                grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    private void Move(float move, bool jump)
    {
        // **Bewegen**
        Vector3 targetVelocity = new Vector2(move * speed, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

        // **Flip als nodig**
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        // **Springen (alleen als je op de grond staat)**
        if (grounded && jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Reset Y snelheid
            rb.AddForce(Vector2.up * jumpForce);
            grounded = false;
        }
        if (grounded == false)
        {
            animator.SetBool("Jump", true);
        }
        else { animator.SetBool("Jump", false); }
       

    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = GameobjectCat.transform.localScale;
        scale.x = facingRight ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
        GameobjectCat.transform.localScale = scale;
    }
}
