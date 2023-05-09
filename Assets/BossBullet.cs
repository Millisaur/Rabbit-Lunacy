using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int damage = 1;

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    //bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        // Destroy the bullet game object after 2 seconds
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject impactEffectObject = Instantiate(impactEffect, transform.position, transform.rotation);
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
            Destroy(impactEffectObject, 3f);
        }
        Destroy(gameObject, 3f);
    }
}
