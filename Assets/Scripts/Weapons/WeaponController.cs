using GameFlow;
using UnityEngine;

namespace Weapons
{
    public class WeaponController : MonoBehaviour
    {
        private const float Force = 20f;

        [SerializeField] private Transform firePoint;
        [SerializeField] private Transform firePoint2;

        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject bullet2;

        [SerializeField] private float fireRate = 10;
        
        private float _timeStamp;
        private float _lastTimeLaserWasFired;
        private float _orbDamageTime;

        private void Update()
        {

            if (Input.GetButton("Fire1"))
            {
                ShootLaser(); 
            }  

            if (Input.GetButtonDown("Fire2"))
            {
                if (PlayerPrefs.GetInt("orbCount") > 0) 
                {
                    ShootOrb();
                    ScoreManager.DecrementOrbCount();
                }
            }

            if (!(_orbDamageTime < Time.time)) 
                return;
            var orbs = FindObjectsOfType<OrbVortex>();
            foreach (var orb in orbs)
            {
                Destroy(orb.gameObject);
            }
        }

        private void ShootLaser()
        {
            if (!(Time.time - _lastTimeLaserWasFired > 1 / fireRate)) 
                return;
            _lastTimeLaserWasFired = Time.time;
            GameObject bulletInstance = Instantiate(bullet, firePoint.position, firePoint.rotation);  
            AudioManager.PlayLaserSound();
            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>(); 
            rb.AddForce(firePoint.right * Force, ForceMode2D.Impulse);
        }

        private void ShootOrb() 
        {
            GameObject bulletInstance = Instantiate(bullet2, firePoint2.position, firePoint2.rotation); 
            _orbDamageTime = Time.time + 4.0f; 
        
            Rigidbody2D rb = bulletInstance.GetComponent<Rigidbody2D>(); 
            rb.AddForce(firePoint2.up * (Force / 4), ForceMode2D.Impulse); 
        }
    }
}   
