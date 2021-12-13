using System.Collections;
using UnityEngine;

public class BarrelHealth : MonoBehaviour
{
    [SerializeField] private float barrelHealth;
    private Animator anim;
    public float currentHealth { get; private set; }    
    private bool exploded;

    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = barrelHealth;        
        spriteRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, barrelHealth);

        if (currentHealth > 0)
        {            
            StartCoroutine(dmg());            
        }
        else
        {
            if (!exploded)
            {
                anim.SetTrigger("explode");
                Destroy(gameObject, 2);
                exploded = true;
            }
        }
    }
   
    private IEnumerator dmg()
    {
        spriteRend.color = new Color(1, 0, 0, 0.5f);
        yield return new WaitForSeconds(0.5f);
        spriteRend.color = Color.white;
    }
}
