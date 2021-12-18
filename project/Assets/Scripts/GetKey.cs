using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetKey : MonoBehaviour
{
    public string pickupName;
    public int amount;
    public GameManager gameManager;
    
    void Update()
    {
        transform.Rotate(Vector3.back * 20 * Time.deltaTime);
    }
   
   void OnTriggerEnter2D(Collider2D other)
    {
        print(pickupName + "obtained");
        gameManager.hasKey = true;
        Destroy(gameObject);
        SceneManager.LoadScene("Bedroom", LoadSceneMode.Single);
    }
}
