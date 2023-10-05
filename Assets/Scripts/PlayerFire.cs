using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public Transform gunNozzle;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireRate, baseFireRate;

    // Start is called before the first frame update
    void Start()
    {
        baseFireRate = fireRate;   
    }

    // Update is called once per frame
    void Update()
    {

        fireRate -= Time.deltaTime;
        if ( fireRate <= 0 )
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunNozzle.position, gunNozzle.rotation) as GameObject;
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(gunNozzle.forward * bulletSpeed, ForceMode.Impulse);
        fireRate = baseFireRate;
    }
}
