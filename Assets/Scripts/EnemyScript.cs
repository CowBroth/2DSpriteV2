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

        float eP = transform.position.x;
        float pP = player.transform.position.x;

        if (pP > eP)
        {
            helper.FlipObject(true);
            rb.velocity = new Vector2(2f, rb.velocity.y);
        }
        if (pP < eP)
        {
            helper.FlipObject(false);
            rb.velocity = new Vector2(-2f, rb.velocity.y);
        }

    }

}
