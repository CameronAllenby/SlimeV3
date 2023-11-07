using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBoi : MonoBehaviour
{
    public GameObject Ball;
    public GameObject Dart;
    public GameObject Point;
    Transform spawn;
    Hscript helper;
    Rigidbody2D rb;
    //Animator anim;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {

        helper = gameObject.AddComponent<Hscript>();
        
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    

    private void FixedUpdate()
    {

    }

    bool flip = false;
    
    // Update is called once per frame
    void Update()
    {
        int moveDirection = 1;

        if (Input.GetKeyDown("e"))
        {
            
            // Instantiate the bullet at the position and rotation of the player
            GameObject clone;
            clone = Instantiate(Ball, transform.position, transform.rotation);


            // get the rigidbody component
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();


            // set the velocity
            if (flip == false)
            {
                rb.velocity = new Vector3(5 * moveDirection, 0, 0);
            }
            else
            {
                rb.velocity = new Vector3(-5 * moveDirection, 0, 0);
            }


            // set the position close to the player
            rb.transform.position = new Vector3(transform.position.x, transform.position.y +
            0.2f, transform.position.z + 0.1f);
        }
        if (Input.GetKeyDown("r"))
        {
            // Instantiate the bullet at the position and rotation of the player
            GameObject clone;
            clone = Instantiate(Dart, transform.position, transform.rotation);


            // get the rigidbody component
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();


            // set the velocity
            rb.velocity = new Vector3(15 * moveDirection, 0, 0);


            // set the position close to the player
            rb.transform.position = new Vector3(transform.position.x, transform.position.y +
            2, transform.position.z + 1);
        }



        int speed = 3;
       // anim.speed = 1;
        Vector2 velocity = rb.velocity;
        //anim.SetBool("run", false);
        //anim.SetBool("jump", false);

        if (Input.GetKey("v") == true)
        {
         //  anim.speed = 10;
            speed = 10;
        }

        if (Input.GetKeyDown("s"))
        {
           // anim.SetTrigger("attack2");


        }
        if (Input.GetKeyDown("e"))
        {
            //anim.SetTrigger("attack1");
        }

        if (helper.DoRayCollisionCheck() == true)
        {
            if (Input.GetKey("space"))
            {
                velocity.y = 10f;
                

            }
        }
        if (helper.DoRayCollisionCheck() == false)
        {
           //anim.SetBool("jump", true);
        }




        

        if (Input.GetKey("a") == true)
        {
            
            sr.flipX = true;
            flip = true;
            //anim.SetBool("run", true);

            //transform.position = new Vector2(transform.position.x + (-speed * Time.deltaTime), transform.position.y);
            velocity.x = -speed;
        }
        if (Input.GetKey("d") == true)
        {
            
           // anim.SetBool("run", true);
           flip = false;
            sr.flipX = false;
            //transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            velocity.x = speed;
        }


        rb.velocity = velocity;




    }
    void OnTriggerEnter2D(Collider2D col)
    {
        print("Collided with " + col.gameObject.name);


        Vector2 velocity = rb.velocity;

        if (col.gameObject.name == "EnimSime")
        {
            if (flip == false)
            {
                velocity.x = 8;
            }
                
            else
            {
                velocity.x = -8;
            }
        }
        if (col.gameObject.name == "Tilemap")
        {
            transform.position = spawn.position;
        }
        rb.velocity = velocity;
        

    }


}
