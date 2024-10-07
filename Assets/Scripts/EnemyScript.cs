using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    HelperScript helper;
    SpriteRenderer sr;
    public GameObject player;
    Rigidbody2D rb;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {

        helper = gameObject.AddComponent<HelperScript>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        Patrol();

    }

    void Patrol()
    {

        bool change = helper.PatrolRaycast();

        if (change)
        {
            helper.FlipObject(true);
            rb.velocity = new Vector2(2f, rb.velocity.y);
        }
        if (!change)
        {
            helper.FlipObject(false);
            rb.velocity = new Vector2(-2f, rb.velocity.y);
        }

    }

}
