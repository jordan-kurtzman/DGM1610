using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   // public GameObject bulletPrefab; (old code)
    public ObjectPool bulletPool; // new code
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float shootRate;
    private float lastShootTime;
    private bool isPlayer;

    void Awake()
    {
        // disable cursor
        Cursor.lockState = CursorLockMode.Locked;
        if(GetComponent<PlayerController>())
            isPlayer = true;

    }
    public bool CanShoot()
    {
        if(Time.time - lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
            return true;
        }
       
        return false;
      
    }
    public void Shoot ()
    {
        // cooldown
        lastShootTime = Time.time;
        curAmmo--;
        // creating instance on the bulled prefab at muzzle's position and rotation
        // GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation); (old code)
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;
        // add velocity to projectile
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
}
