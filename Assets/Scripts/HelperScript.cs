using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{

    LayerMask floorMask;

    void Start()
    {

        floorMask = LayerMask.GetMask("Floor");

    }

    public void FlipObject(bool flip)
    {

        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

    }

    public bool GroundRaycast()
    {

        bool colBool = false;
        float rLength = 0.25f;
        Vector3 offset1 = new Vector3(-0.3f, 0, 0);
        Vector3 offset2 = new Vector3(0.3f, 0, 0);
        Color rayC = Color.white;

        RaycastHit2D ray1 = Physics2D.Raycast(transform.position + offset1, Vector2.down, rLength, floorMask);
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, Vector2.down, rLength, floorMask);

        if (ray1.collider != null && ray2.collider != null)
        {
            colBool = true;
            rayC = Color.green;
        }

        Debug.DrawRay(transform.position + offset1, Vector2.down * rLength, rayC);
        Debug.DrawRay(transform.position + offset2, Vector2.down * rLength, rayC);
       
        return colBool;

    }

}
