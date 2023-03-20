using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    //if (myPlayerHealthScript.isAlive == false) { return; }

    [Header("Player movement variabelen")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpHeight = 10f;
    [SerializeField] float dashSpeed = 10f;
    [SerializeField] float climbSpeed = 10f;
    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    
    [Header("Dash variabelen")]
    [SerializeField] float DashMeter = 1f;
    
    CapsuleCollider2D myCapsuleCollider2D;
    Rigidbody2D myRigidbody2D;
    PlayerHealth myPlayerHealthScript;
    Animator myAnimator;
    SpriteRenderer mySpriteRenderer;

    float isDamegedTime = 0.5f;
    float gravityScaleOnStart;

    bool canDash = true;

    void Awake()
    {
        myPlayerHealthScript = FindObjectOfType<PlayerHealth>();
    }

    void Start()
    {
        myCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myPlayerHealthScript = GetComponent<PlayerHealth>();
        myAnimator = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        gravityScaleOnStart = myRigidbody2D.gravityScale;
    }

    void Update()
    {
        Movement();
        Jumping();
        Dash();
        ClimbLadder();
    }

    void Movement()
    {
        if (myPlayerHealthScript.isAlive == false) { return; }
        if (Input.GetKey(KeyCode.A))
        {
            mySpriteRenderer.flipX = enabled;
            myAnimator.SetBool("IsRunning", true);
            transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            mySpriteRenderer.flipX = !enabled;
            myAnimator.SetBool("IsRunning", true);
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        }
        else
        {
            myAnimator.SetBool("IsRunning", false);
        }
    }

    void Jumping()
    {
        if (myPlayerHealthScript.isAlive == false) { return; }
        if (!myCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetBool("Isjumping", true);
            myRigidbody2D.velocity += new Vector2(0, jumpHeight);
        }
        else
        {
            myAnimator.SetBool("Isjumping", false);
        }
    }

    void Dash()
    {
        if (myPlayerHealthScript.isAlive == false) { return; }
        if (!canDash) { return; }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            myRigidbody2D.velocity += new Vector2(-dashSpeed, 0);
            StartCoroutine(DashTime());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            myRigidbody2D.velocity += new Vector2(dashSpeed, 0);
            StartCoroutine(DashTime());
        }
    }

    void ClimbLadder()
    {
        if (!myCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            myRigidbody2D.gravityScale = gravityScaleOnStart;
            myAnimator.SetBool("IsClimbing", false);
            return; 
        }

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody2D.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("IsClimbing", playerHasVerticalSpeed);

        if (Input.GetKey(KeyCode.W))
        {
            Vector2 climbVelocity = new Vector2(myRigidbody2D.velocity.x, 1 * climbSpeed);
            myRigidbody2D.velocity = climbVelocity;
            myRigidbody2D.gravityScale = 0f;
        }
        
    }
        

    IEnumerator DashTime()
    {
        canDash = false;
        Debug.Log(canDash);
        yield return new WaitForSeconds(DashMeter);
        canDash = true;
        Debug.Log(canDash);
    }

    public void TakingDamage()
    {
        // maak variablen die de oude postien en de nieuwe postien
        //
        float oldPos;
        float newPos;
        oldPos = myRigidbody2D.position.x;
        newPos = myRigidbody2D.position.x;
        
        if(newPos > oldPos)
        {
            Debug.Log("Works");
        }
        //
        
        
        StartCoroutine(DamageTime());
        myRigidbody2D.velocity = deathKick;
        myPlayerHealthScript.LoseHealth();
    }

    IEnumerator DamageTime()
    {
        myAnimator.SetBool("IsDamaged", true);
        yield return new WaitForSeconds(isDamegedTime);
        myAnimator.SetBool("IsDamaged", false);
    }
}