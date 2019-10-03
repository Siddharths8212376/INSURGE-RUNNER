using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // declare all the required variables
    public CharacterController2D controller;
    public float runSpeed = 50f;
    public float horizontalMove = 0f;
    public bool jump = false;
    public bool crouch = false;
    public bool gotHit = false;
    public Animator animator;
    private Rigidbody2D rb;
    public GameObject GameOverText, RestartButton;
    public GameManager gameManager;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameOverText.SetActive(false);
        RestartButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        // Debug.Log(Input.GetAxisRaw("Horizontal"));
        horizontalMove = runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("isCrouching", true);
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("isCrouching", false);
        }
        
    }
    // adding the onLanding event
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    public void OnCrouch(bool onCrouch)
    {
        animator.SetBool("isCrouching", onCrouch);
    }
    // FixedUpdate is called a certain number of times every frame
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }
    // adding the on-collision method
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Obstacle"))
        {
            gotHit = true;
            animator.SetBool("gotHit", true);
            gameManager.GameOver();
            // GameOverText.SetActive(true);
            // RestartButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
