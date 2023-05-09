using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public Transform bossTrans;
    public bool boss = false;
    public GameObject bossObject;
    public Transform spawnPoint;

    private CinemachineVirtualCamera vcam;
    private PlayerBound player;
    private BoxCollider2D boxCollider2D;
    
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        bossObject = GameObject.Find("Boss");
        player = GameObject.Find("Player").GetComponent<PlayerBound>();
        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
    }

    void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{   
            boss = true;
            bossObject.GetComponent<Boss>().enabled = true;
            bossObject.GetComponent<BossHealth>().enabled = true;
            bossObject.GetComponent<BossWeapon>().enabled = true;
            bossObject.GetComponent<Animator>().enabled = true;
            Rigidbody2D rb2d = bossObject.GetComponent<Rigidbody2D>();
            rb2d.simulated = true;
            Debug.Log("Boss spawned");
            vcam.Follow = bossTrans;
            player.boundaryLeft = 148f;
            player.boundaryRight = 168f;
            boxCollider2D.enabled = false;
            FindObjectOfType<AudioManager>().Play("BossLaugh");
		}
	}
}
