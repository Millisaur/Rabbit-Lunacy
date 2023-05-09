using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour
{
    //[Header("Health")]
    public float currentHealth { get; private set;}
    public GameManagerScript gameManager;

    private Animator anim;
    private bool dead;

    [SerializeField] private float startingHealth;

    //[Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        
        if(currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
        else
        {
            if(!dead)
            {
                anim.SetTrigger("die");
                GetComponent<playerMovement>().enabled = false;
                dead = true;

                FindObjectOfType<AudioManager>().Play("PlayerDeath");

                StartCoroutine(DisableGameObject());
                gameManager.gameOver();
            }
            
        }
    }

    private IEnumerator DisableGameObject()
{
    yield return new WaitForSeconds(3f);
    gameObject.SetActive(false);
}

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0 , startingHealth);
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(8, 10, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            Color c = spriteRend.color;
            c.a = 0.5f;
            spriteRend.color = c;
            yield return new WaitForSeconds(0.2f);
            c.a = 1f;
            spriteRend.color = c;
            yield return new WaitForSeconds(0.2f);
        }
        Physics2D.IgnoreLayerCollision(8, 10, false);
    }

}
