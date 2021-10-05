using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10.0f;
    public float hInput;
    public float vInput; 

    public float xRange = 9f;
    public float yRange = 7f;

    public GameObject projectile;
    public Transform launcher;
    public Vector3 offset = new Vector3(0,1,0);

    // public float health

    
    // Update is called once per frame
    void Update()
    {
       hInput = Input.GetAxis("Horizontal");
       vInput = Input.GetAxis("Vertical");

       transform.Translate(Vector3.right * speed * hInput * Time.deltaTime);
       transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);
       
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
        // create wall on y side
        if(transform.position.y > yRange)
       {
           transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
       }
    
       if(Input.GetKeyDown(KeyCode.Space))
       {
           Instantiate(projectile, launcher.transform.position, launcher.transform.rotation);
       }
    }
}
