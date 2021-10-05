using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float hInput;
    public float vInput; 

    public float xRange = 10f;
    public float yRange = 0f;


    public Vector3 offset = new Vector3(0,1,0);

    // public float health

    
    // Update is called once per frame
    void Update()
    {
       hInput = Input.GetAxis("Horizontal");

       transform.Translate(Vector3.right * speed * hInput * Time.deltaTime);
       
       // create wall on -x side
       if(transform.position.x < -xRange)
       {
           transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
       }
        // create wall on x side
       if(transform.position.x > xRange)
       {
           transform.position = new Vector3( xRange, transform.position.y, transform.position.z);
        }
       // create wall on -y side
        if(transform.position.y < -yRange)
       {
           transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
       }

    }
}

