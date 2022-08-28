using UnityEngine.Audio;
using UnityEngine;
using TMPro;

public class WeaponController : MonoBehaviour
{
    const float force = 20f;

    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint2;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bullet2;
    
    float timeStamp;
    float fireRate = 10;
    float lastTimeLaserWasFired;
    float orbDamageTime;

    void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            shootLaser(); 
        }  

        if (Input.GetButtonDown("Fire2"))
        {
            if (PlayerPrefs.GetInt("orbCount") > 0) 
            {
                shootOrb();
                ScoreManager.decrementOrbCount();
            }
        }

        if (orbDamageTime < Time.time) 
        {
            var orbs = FindObjectsOfType<orbVortex>();
            foreach (var orb in orbs)
            {
                Destroy(orb.gameObject);
            }
        }
    }                       
    void shootLaser()
    {
        if (Time.time - lastTimeLaserWasFired > 1 / fireRate)
        {
            lastTimeLaserWasFired = Time.time;
            GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation);  
            AudioManager.playLaserSound();
            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>(); 
            rb.AddForce(firePoint.right * force, ForceMode2D.Impulse); 
        }
    }
    void shootOrb() 
    {
        GameObject bulletInstance = Instantiate(bullet2, firePoint2.position, firePoint2.rotation); 
        orbDamageTime = Time.time + 4.0f; 
        
        Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>(); 
        rb.AddForce(firePoint2.up * (force / 4), ForceMode2D.Impulse); 
    }
}   
