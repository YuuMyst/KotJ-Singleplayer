using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //SerializeField - allow you to change the variable in Unity    
    //LayerMask - used to isolate code to a specific layer(s)
        
    //Movement variables
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [SerializeField] private LayerMask groundLayer;    

    private float horizontalInput;

    //Object references
    private Rigidbody2D body;    
    private BoxCollider2D hitbox;
    private Animator anim;

    private bool flip = false;

    private void Awake() 
    {
        //Stores references for rigidbody, boxcollider & animator
        body = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //Controls player movement left-right

        //Flips playermodel when moving left-right
        if (horizontalInput > 0.01f) {
            transform.localScale = Vector3.one; //sets all values to 1
            flip = false;
        }
            
        else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1); //flips the player on x axis
            flip = true;
        }
            

        //Animator parameters to check if moving
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        body.gravityScale = 7;

        if (Input.GetKey(KeyCode.Space))
            Jump();

    }

    private void Jump() 
    {
        if (isGrounded()) //checks if player is on ground
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower); //moves player vertically using jumpPower
            anim.SetTrigger("jump"); //jump animation
        }
    }

    private bool isGrounded() {
        RaycastHit2D raycastHit = Physics2D.BoxCast(hitbox.bounds.center, hitbox.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    //Prevents player shooting whilst moving/jumping
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded();
    }

    public bool isFlip() {
        return flip;
    }
}
