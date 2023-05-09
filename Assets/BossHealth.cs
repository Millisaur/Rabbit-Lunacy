using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 500;
	public GameManagerScript gameManager;

    // public GameObject deathEffect;

    [SerializeField] private float damage;

    public Animator animator; // reference to the animator component

    private bool isEnraged = false;
	private Boss boss;
	private BossWeapon bossWeapon;

	private void Start()
	{

		boss = GetComponent<Boss>();
		bossWeapon = GetComponent<BossWeapon>();
	}

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
        else if (health <= 250 && !isEnraged) // health below 50%
        {
			FindObjectOfType<AudioManager>().Play("BossRage");
			bossWeapon.difficulty1 = 2.5f;
			bossWeapon.difficulty2 = 3f;
			boss.jumpDifficulty = 3f;
            isEnraged = true;
            animator.SetBool("isEnraged", true); // set the animator's bool parameter
			StartCoroutine(Invunerability());
        }
    }

    public void Die ()
	{
		FindObjectOfType<AudioManager>().Play("BossDeath");
		animator.SetTrigger("Dead");
        GetComponent<Boss>().enabled = false;
		GetComponent<BossWeapon>().enabled = false;
        StartCoroutine(DisableGameObject());
		StartCoroutine(Invunerability());
	}

	private IEnumerator DisableGameObject()
	{
		yield return new WaitForSeconds(2f);
		gameObject.SetActive(false);
		Debug.Log("death");
		gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
		gameManager.CompleteLevel();
	}

    void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			collision.GetComponent<Health>().TakeDamage(damage);
		}
	}

	private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 12, true);
		yield return new WaitForSeconds(1.5f);
		Physics2D.IgnoreLayerCollision(8, 12, false);
    }
}
