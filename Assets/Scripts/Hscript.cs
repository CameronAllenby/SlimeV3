using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hscript : MonoBehaviour
{
    LayerMask groundLayerMask;
    void Start()
    {
        // set the mask to be "Ground"
        groundLayerMask = LayerMask.GetMask("Ground");
    }



    public bool DoRayCollisionCheck()
    {
        float rayLength = 0.05f; // length of raycast
        Vector3 rayOffset1 = new Vector3(0, 0f, 0);
        Vector3 rayOffset2 = new Vector3(-0.1f, 0f, 0);
        Vector3 rayOffset3 = new Vector3(0.1f, 0f, 0);

        //cast a ray downward 
        RaycastHit2D hit;
        RaycastHit2D hit2;
        RaycastHit2D hit3;

        hit = Physics2D.Raycast(transform.position + rayOffset1, Vector2.down, rayLength, groundLayerMask);
        hit2 = Physics2D.Raycast(transform.position + rayOffset2, Vector2.down, rayLength, groundLayerMask);
        hit3 = Physics2D.Raycast(transform.position + rayOffset3, Vector2.down, rayLength, groundLayerMask);
        bool ground = false;
        Color hitColor = Color.white;


        if (hit.collider != null || hit2.collider != null || hit3.collider != null)
        {
            
            ground = true;
            hitColor = Color.green;

        }
        else
        {
            ground = false;
        }

        Debug.DrawRay(transform.position + rayOffset1, -Vector2.up * rayLength, hitColor);
        Debug.DrawRay(transform.position + rayOffset2, -Vector2.up * rayLength, hitColor);
        Debug.DrawRay(transform.position + rayOffset3, -Vector2.up * rayLength, hitColor);

        return ground;
    }

    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        // Start is called before the first frame update

    }
    public int Pacing()
    {
        float rayLength = 0.05f; // length of raycast
        Vector3 rayOffset1 = new Vector3(0, 0f, 0);
        Vector3 rayOffset2 = new Vector3(-0.1f, 0f, 0);
        Vector3 rayOffset3 = new Vector3(0.1f, 0f, 0);


        //cast a ray downward 
        RaycastHit2D hit;
        RaycastHit2D hit2;
        RaycastHit2D hit3;


        hit = Physics2D.Raycast(transform.position + rayOffset1, Vector2.down, rayLength, groundLayerMask);
        hit2 = Physics2D.Raycast(transform.position + rayOffset2, Vector2.down, rayLength, groundLayerMask);
        hit3 = Physics2D.Raycast(transform.position + rayOffset3, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.white;
        int flip = 1;

        if (hit3.collider != null && hit2.collider == null)
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            
            hitColor = Color.green;
            flip = 2;
        }
        if (hit2.collider != null && hit3.collider == null)
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            
            hitColor = Color.green;
            flip = 3;
        }
        if (hit2.collider != null && hit3.collider != null && hit.collider != null)
        {
            
            flip = 1;
        }

        Debug.DrawRay(transform.position + rayOffset1, -Vector2.up * rayLength, hitColor);
        Debug.DrawRay(transform.position + rayOffset2, -Vector2.up * rayLength, hitColor);
        Debug.DrawRay(transform.position + rayOffset3, -Vector2.up * rayLength, hitColor);

        return flip;
    }
    
}
    