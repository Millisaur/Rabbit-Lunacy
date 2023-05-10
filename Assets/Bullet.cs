using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    bool check = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        // Destroy the bullet game object after 2 seconds
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject.CompareTag("Enemy") && !check)
        {
            check = true;
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy)
            {   
                enemy.TakeDamage(damage);
                FindObjectOfType<AudioManager>().Play("BulletImpact");
            }
            else
            {
                BossHealth enemy1 = hitInfo.GetComponent<BossHealth>();
                if (enemy1)
                {   
                    enemy1.TakeDamage(damage);
                    FindObjectOfType<AudioManager>().Play("BulletImpact");
                }
            }


            GameObject impactEffectObject = Instantiate(impactEffect, transform.position, transform.rotation);

            // Destroy the impact effect game object after 2 seconds
            Destroy(impactEffectObject, 3f);

            Destroy(gameObject);
        }
    }

}
