using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Script : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpHeight = 10f;

    [Header("Raycast")]
    [SerializeField] LayerMask groundMask;
    [SerializeField] Transform foot;

    Rigidbody2D myRigidbody2D;
    Animator myAnimator;

    public bool Isrunning;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        SideMovement();
        Jump();
        PlayerAnim();
    }

    void SideMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector2(-1, 1);
            Isrunning = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
            transform.localScale = new Vector2(1, 1);
            Isrunning = true;
        }
        else
        {
            Isrunning = false;
        }
    }

    private bool CheckGrounding()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(foot.position, Vector2.down, 1.0f, groundMask);

        return hit;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounding())
        {
            myRigidbody2D.velocity += new Vector2(0, jumpHeight);
        }
    }

    void PlayerAnim()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            myAnimator.SetBool("IsRunning", true);
        }
        else
        {
            myAnimator.SetBool("IsRunning", false);
        }
    }
}
