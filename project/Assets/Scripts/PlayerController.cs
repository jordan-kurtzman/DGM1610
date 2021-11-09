using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float hInput;
    public float vInput;
    private float xRange = 8f;
    private float yRangeTop = 1.5f;
    private float yRangeBottom = 3f;

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
        if(transform.position.y < -yRangeBottom)
       {
           transform.position = new Vector3(transform.position.x, -yRangeBottom, transform.position.z);
       }
        // create wall on y side
        if(transform.position.y > yRangeTop)
       {
           transform.position = new Vector3(transform.position.x, yRangeTop, transform.position.z);
       }
    }
}
