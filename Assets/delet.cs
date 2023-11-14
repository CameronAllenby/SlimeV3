using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delet : MonoBehaviour
{
    public GameObject spawn;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    int life = 3;
    // Update is called once per frame
    void Update()
    {
        if (life == 0)
        {
            Destroy(Player.gameObject);
        }
        
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        print("Collided with " + col.gameObject.name);



        if (col.gameObject.name == "slimeball(Clone)")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            Player.transform.position = spawn.transform.position;
            life--;

        }
        else
        {

        }
    }
}
