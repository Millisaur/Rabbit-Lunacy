using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float jumpingPower = 16f;
    public float speed = 8f;
    public Animator animator;
    public float hopDuration = 0.5f;

    private Rigidbody2D rb;
    private bool isHopping = false;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(AutoHop());
    }

    private IEnumerator AutoHop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            if (!isHopping)
            {
                FindObjectOfType<AudioManager>().Play("BunnyHop");
                isHopping = true;
                rb.velocity = new Vector2(-speed, jumpingPower);
                yield return new WaitForSeconds(hopDuration);
                rb.velocity = new Vector2(0f, rb.velocity.y);
                isHopping = false;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void FixedUpdate()
    {
        if (!isHopping)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }

    private void Update()
    {
        if(!IsGrounded())
        {
            animator.SetBool("isHopping", true);
        }
        else
        {
            animator.SetBool("isHopping", false);
        }
    }
}


