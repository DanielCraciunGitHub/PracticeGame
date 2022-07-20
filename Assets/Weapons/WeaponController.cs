using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponController : MonoBehaviour
{
    const float force = 20f;

    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint2;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet2;

    [SerializeField] TMP_Text orbs;

    float timeStamp;
    float fireRate = 10;
    float lastFired;
    float orbTimeStamp;

    void Update()
    {
        orbs.text = $"Orbs: x{PlayerPrefs.GetInt("orbCount")}"; // keep updating the orbs of the player

        if (Input.GetButton("Fire1"))
        {
            shoot(); // shoot a bullet
        }  

        if (Input.GetButtonDown("Fire2"))
        {
            if (PlayerPrefs.GetInt("orbCount") > 0) // if the time passes 10 seconds since last shot with orb and have enough orbs
            {
                shoot2();
                int orbs = PlayerPrefs.GetInt("orbCount") - 1;
                PlayerPrefs.SetInt("orbCount", orbs);
            }
        }

        if (orbTimeStamp < Time.time) // manage time since orb is alive
        {
            var orbs = FindObjectsOfType<orbVortex>();
            foreach (var orb in orbs) // destroys orb/orbs if time passes
            {
                Destroy(orb.gameObject);
            }
        }
    }                       
    void shoot()
    {
        if (Time.time - lastFired > 1 / fireRate)
        {
            lastFired = Time.time;
            GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation); // creates an instance of a bullet object
            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>(); // get rigidbody of new bullet
            rb.AddForce(firePoint.right * force, ForceMode2D.Impulse); // apply a force to it
        }
    }
    void shoot2() // same as the function above, but a different firePoint is used
    {
        GameObject bulletInstance = Instantiate(bullet2, firePoint2.position, firePoint2.rotation); // creates an instance of a bullet object
        orbTimeStamp = Time.time + 4.0f; // orb survives for 4 seconds if no collisions
        
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>(); // get rigidbody of new bullet
        rb.AddForce(firePoint2.up * (force/4), ForceMode2D.Impulse); // apply a force to it

    }
}   
