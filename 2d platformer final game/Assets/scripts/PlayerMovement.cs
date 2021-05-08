using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxSpeed;
    private float _speed;
    public bool facingRight = true;
    public bool isGrounded;
    public bool inWater;
    public float jumpForce;
     Animator animator;
    public ParticleSystem splash;
    public AudioSource Splash;
    public bool isTired;
    HealthManager healthManager;
    public static PlayerMovement player;


    // Functions 
    private void Awake()
    {
        player = this;
    }
    void Start()
    {
        Stamina.instance.player = this;
        _speed = maxSpeed;
        rb2d=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _speed = maxSpeed;
            isGrounded = true;
            inWater = false;
            Debug.Log("col");
            animator.SetBool("IsJumping", false);
        }
    }
   
    void Update()
    {
        //PlayerMovement 
        float x = Input.GetAxisRaw("Horizontal");      
        Vector2 targetVelocity = new Vector2(x * _speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetVelocity, ref targetVelocity, Time.deltaTime );
        
        animator.SetBool("IsJumping", !isGrounded);
        animator.SetBool("IsRunning", x != 0);


        //jump 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rb2d.AddForce(new Vector2(0f,jumpForce));
            isGrounded = false;
            if (inWater)
            {
                _speed = maxSpeed;
                inWater = false;
                splash.Play();
                Splash.Play();
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {

            //animator.SetTrigger("Attack");
        }
        //sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Sprint();
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = maxSpeed;
        }
       
        //chouf ken niflipiou ala le
        if (x>0 && !facingRight)
        {
            Flip();
        }
        else if(x<0 && facingRight)
        {
            Flip();
        }
    }
    
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lac"))
        {
            isGrounded = true;
            inWater = true;
            splash.Play();
            Splash.Play();
            _speed = maxSpeed / 2;
        }
    }
    public void Sprint()
    {
        //if (isTired) return;
        _speed = maxSpeed * 2;
        Debug.Log(_speed);
        Stamina.instance.Stamuna(40);
    }
   public  void Die()
   {
       
        animator.SetBool("IsDead", true);
        StartCoroutine("DieTime");
        
   }

    IEnumerator DieTime()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0); 
    }
}
