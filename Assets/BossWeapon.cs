using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float randomShoot;
	public float randomTime1;
    public Animator animator;
    public float difficulty1 = 1.5f;
    public float difficulty2 = 2.4f;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Shoot());
    }
    void Update()
    {
        
    }
    void SetAttackingFalse()
    {
        animator.SetBool("Attacking", false);
    }

    private IEnumerator Shoot()
    {
        while(true)
        {
            randomTime1 = Random.Range(0.6f, 2);
            yield return new WaitForSeconds(randomTime1);

            // Check if boss is not currently in intro or enraged animation
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            bool isIntroOrEnragedAnimation = stateInfo.IsName("Boss_Intro") || stateInfo.IsName("Boss_Rage");
            if(!isIntroOrEnragedAnimation)
            {
                randomShoot = Random.Range(0, 3);
                if(randomShoot < difficulty1)
                {
                    FindObjectOfType<AudioManager>().Play("BossShoot");
                    animator.SetBool("Attacking", true);
                    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                }
                if(!GetComponent<Boss>().IsGrounded() && randomShoot < difficulty2)
                {
                    FindObjectOfType<AudioManager>().Play("BossShoot");
                    animator.SetBool("Attacking", true);
                    randomTime1 = Random.Range(0.3f, 0.6f);
                    yield return new WaitForSeconds(randomTime1);
                    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                }
            }
        }
    }
}
