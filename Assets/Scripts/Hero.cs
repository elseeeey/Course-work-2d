using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // скорость движения
    [SerializeField] private int lives = 5; // скорость движения
    [SerializeField] private float jumpForce = 15f; // сила прыжка
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    //private void FixedUpdate()
    //{
    //    CheckGround();
    //}

    private void Update()
    {
        if (isGrounded) State = States.idle;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetButton("Horizontal"))
            Run();
        ////if (Input.GetButton("Jump") /*&& isGrounded*/)
        ////{
        ////    Jump();
        ////    isGrounded = false;
        ////}
        //print(isGrounded);


        //if (isGrounded && Input.GetButtonDown("Jump"))
        //{
        //    print("123");
        //    Debug.Log("Jump");
        //    Jump();
        //}


    }

    private void Run()
    {
        if (isGrounded) State = States.run;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    //private void CheckGround()
    //{
    //    Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
    //    isGrounded = collider.Length > 1;

    //    if (isGrounded) State = States.jump;
    //}

}
    public enum States
    {
        idle,
        run,
        jump
    }

