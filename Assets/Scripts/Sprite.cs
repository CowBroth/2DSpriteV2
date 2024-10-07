using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite : MonoBehaviour
{

    HelperScript helper;
    Rigidbody2D rigidBody;
    Animator animator;
    SpriteRenderer spriteRen;
    Transform transform;

    bool isFalling = false;
    bool isJumping = false;
    bool isAttack = false;
    bool isWalking = false;

    float nPos;
    float oPos;

    // Start is called before the first frame update
    void Start()
    {

        helper = gameObject.AddComponent<HelperScript>();
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRen = GetComponent<SpriteRenderer>();
        transform = GetComponent<Transform>();

        animator.SetBool("isWalk", false);
        animator.SetBool("isJump", false);
        animator.SetBool("isFall", false);
        animator.SetBool("isGrounded", false);


    }

    // Update is called once per frame
    void Update()
    {

        MoveSprite();
        oPos = transform.position.y;

    }

    void MoveSprite()
    {

        nPos = transform.position.y;

        bool isGrounded = helper.GroundRaycast();

        if (Input.GetKey("left"))
        {
            helper.FlipObject(true);
            rigidBody.velocity = new Vector2(-5f, rigidBody.velocity.y);
        }

        if (Input.GetKey("right"))
        {
            helper.FlipObject(false);
            rigidBody.velocity = new Vector2(5f, rigidBody.velocity.y);
        }

        if (Input.GetKey("left") && isGrounded || Input.GetKey("right") && isGrounded)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
            animator.SetBool("isFall", false);
            animator.SetBool("isJump", false);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        if (Input.GetKeyDown("z") && isGrounded == true)
        {
            rigidBody.AddForce(new Vector3(0, 12, 0), ForceMode2D.Impulse);
        }

        if (nPos < oPos && !isGrounded)
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isFall", true);
        }

        if (nPos > oPos && !isGrounded)
        {
            animator.SetBool("isFall", false);
            animator.SetBool("isJump", true);
        }

    }

}