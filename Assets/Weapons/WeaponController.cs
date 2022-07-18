using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint2;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet2;

    const float force = 20f;
    float timeStamp;

    void Update()
    {

        if (Input.GetButtonDown("Fire1")) // on clicking the LMB
        {
            shoot(); // shoot a bullet
        }  

        if (Input.GetButtonDown("Fire2"))
        {
            if (timeStamp <= Time.time)
            {
                shoot2();
                timeStamp = Time.time + 3.0f;
            }
        }
    }                       
    void shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation); // creates an instance of a bullet object
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>(); // get rigidbody of new bullet
        rb.AddForce(firePoint.right * force, ForceMode2D.Impulse); // apply a force to it
    }
    void shoot2() // same as the function above, but a different firePoint is used
    {
        GameObject bulletInstance = Instantiate(bullet2, firePoint2.position, firePoint2.rotation); // creates an instance of a bullet object
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>(); // get rigidbody of new bullet
        rb.AddForce(firePoint2.up * (force/4), ForceMode2D.Impulse); // apply a force to it
    }
}   