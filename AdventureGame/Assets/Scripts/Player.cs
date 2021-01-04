using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float runSpeed = 5;
    Animator animator;
    [SerializeField]  float jumpSpeed = 5;
    [SerializeField] float climpSpeed = 5;
    [SerializeField] Vector2 deathKick = new Vector2(125,125);

    float startingGravity;

    bool isAlive=true;

    Collider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
        startingGravity = rigidbody2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
            return;
        Run();
        Flip();
        Jump();
        Climp();
        Die();
    }
    

    private void Run()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 position = new Vector2(horizontal*runSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = position;

        bool hasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("Running", hasHorizontalSpeed);
    }

    private void Climp()
    {
        if (!collider2D.IsTouchingLayers(LayerMask.GetMask("Climp")))
        {
            animator.SetBool("Climp", false);
            rigidbody2D.gravityScale = startingGravity;
            return;
        }
        float horizontal = Input.GetAxis("Vertical");
        Vector2 position = new Vector2(rigidbody2D.velocity.x, horizontal * climpSpeed );
        rigidbody2D.velocity = position;
        rigidbody2D.gravityScale = 0;

        bool hasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.y) > Mathf.Epsilon;
        animator.SetBool("Climp", hasHorizontalSpeed);
    }

    private void Jump()
    {
        if (!collider2D.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rigidbody2D.velocity += jumpVelocity;
        }
    }

    private void Flip()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);
        }
    }

    private void Die()
    {
        if (rigidbody2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            animator.SetBool("Die", true);
            rigidbody2D.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
