using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float shootTime;
    public GameObject hitParticle;


    void OnEnable()
    {
        shootTime = Time.time;

    }

    void OnTriggerEnter(Collider other)
    {
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(obj, 1.0f);
        
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        else if(other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);
        gameObject.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);
    }
}
