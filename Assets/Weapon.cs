using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float counter = 5;
    // Update is called once per frame
    void Start()
    {
       StartCoroutine(ShotCharge());
    }

    void Update()
    {
        
        if(Input.GetButtonDown("Fire1") && counter > 0)
        {
            counter--;
            Shoot();
            FindObjectOfType<AudioManager>().Play("PlayerShoot");
        }
    }

    IEnumerator ShotCharge()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (counter >= 0 && counter < 5)
            {
                counter++;
            }
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }
}
