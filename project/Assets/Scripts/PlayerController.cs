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

    private float xBedRangeLeft = 5f;
    private float xBedRangeRight = 8f;
    private float yBedRangeTop = 1.5f;
    private float yBedRangeBottom = -0.5f;
    public GameManager gameManager;

   // Update is called once per frame
    void Update()
    {
       hInput = Input.GetAxis("Horizontal");
       vInput = Input.GetAxis("Vertical");

       transform.Translate(Vector3.right * speed * hInput * Time.deltaTime);
       transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);
 
        if(gameManager.trapped == true)
         {if(transform.position.x < xBedRangeLeft) 
           {
             transform.position = new Vector3(xBedRangeLeft, transform.position.y, transform.position.z);
           }
           if(transform.position.x > xBedRangeRight)
           {
              transform.position = new Vector3(xBedRangeRight, transform.position.y, transform.position.z);
           }
           if(transform.position.y < -yBedRangeBottom)
           {
              transform.position = new Vector3(transform.position.x, -yBedRangeBottom, transform.position.z);
           }
           if(transform.position.y > yBedRangeTop)
           {
              transform.position = new Vector3(transform.position.x, yBedRangeTop, transform.position.z);
           }
          }
        else
        {if(transform.position.x < -xRange)
         {
           transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
         }
          if(transform.position.x > xRange)
         {
           transform.position = new Vector3( xRange, transform.position.y, transform.position.z);
         }
          if(transform.position.y < -yRangeBottom)
          {
           transform.position = new Vector3(transform.position.x, -yRangeBottom, transform.position.z);
          }
         if(transform.position.y > yRangeTop)
          {
           transform.position = new Vector3(transform.position.x, yRangeTop, transform.position.z);
         }
        }
       
    }
}
