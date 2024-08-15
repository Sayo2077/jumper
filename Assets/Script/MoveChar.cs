using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class MoveChar : MonoBehaviour
{
    public float Hp = 3;
    public float MoveHuman;
    public float speed;
    public float MoveHigh;
    public float CheckJump;
    public float CheckMove;
    public float TakePunch;
    private float number;
    private Rigidbody2D rb;
    private Animator amt;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        amt = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move L,R,U
        if (Input.GetKey(KeyCode.RightArrow) && TakePunch == 0 )
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            transform.localScale = new Vector2(5, 5);
            MoveHuman = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && TakePunch == 0 )
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            transform.localScale = new Vector2(-5, 5);
            MoveHuman = -1;
        }
        else
        {
            MoveHuman = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckJump < 2)
            {
                rb.velocity = new Vector2(rb.velocity.x, MoveHigh);
                CheckJump++;
            }
        }

        //Animation Human
        amt.SetBool("Run", MoveHuman != 0);
        amt.SetBool("Jump", CheckJump < 3 && CheckJump >0);

        //UpSpeed
        if (MoveHuman == 1)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed + 2), rb.velocity.y);
                CheckMove = 0;
            }
        }
        else if (MoveHuman == -1)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed + 2), rb.velocity.y);
                CheckMove = 1;
            }
        }
    }

    //Target Human
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Target Sand
        if (collision.gameObject.CompareTag("Sand"))
        {
            CheckJump = 0;
            TakePunch = 0;
        }
        //Target Rotation
        if (collision.gameObject.CompareTag("Rotation"))
        {
            Hp--;
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * -5, 5);
            TakePunch = 1;
        }
    }

}

