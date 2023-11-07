using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        print("Collided with " + col.gameObject.name);



        if (col.gameObject.name == "slimeball(Clone)")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.name == "SlimeBoi")
        {

        }
        else
        {

        }
    }
}
