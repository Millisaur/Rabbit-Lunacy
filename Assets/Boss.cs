using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    public float jumpingPower = 20f;
    public float speed = 8f;
    public Animator animator;

	public float randomJump;
	public float randomTime;
    public float jumpDifficulty = 2;
    private int currentHealth;
    private Rigidbody2D rb;

	[SerializeField] private LayerMask groundLayer;
	[SerializeField] private Transform groundCheck;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Jump());
    }

    private void Update()
    {
		//Debug.Log(IsGrounded());
        animator.SetBool("IsJumping", !IsGrounded());
    }

	public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.4f, groundLayer);
    }

    private void FixedUpdate()
    {

    }

    private IEnumerator Jump()
    {
		while(true)
		{
			randomTime = Mathf.FloorToInt(Random.Range(1, 3));
			yield return new WaitForSeconds(randomTime);
			if(IsGrounded())
			{
				randomJump = Mathf.FloorToInt(Random.Range(0, 4));
				if(randomJump < jumpDifficulty)
				{
					//Debug.Log("JUMP");
					rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                    FindObjectOfType<AudioManager>().Play("BossHop");
				}

			}
		}
    }
}
