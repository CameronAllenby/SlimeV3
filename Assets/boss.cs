using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class boss : MonoBehaviour
{
    SpriteRenderer sr;
    Hscript helper;
    Collider2D Projectile;
    // Start is called before the first frame update
    void Start()
    {
        helper = gameObject.AddComponent<Hscript>();
        sr = GetComponent<SpriteRenderer>();
        //Projectile = OnTriggerEnter2D(, Projectile);
    }
    int speed = 7;
    int Health = 1000;
    // Update is called once per frame
    void Update()
    {
        print(Health);
        transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        if (helper.Pacing() == 1)
        {

        }
        if (helper.Pacing() == 3)
        {
           
            sr.flipX = true;
            speed = speed * -1;
        }
        if (helper.Pacing() == 2)
        {

            sr.flipX = false;
            speed = speed * -1;
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        

        
        
        if (col.gameObject.name == "slimeball(Clone)")
        {
            Health --;
        }
        if (col.gameObject.name == "SlimeBoi")
        {
            
        }
        else
        {
            Health = Health - 2;
        }

    }


}
