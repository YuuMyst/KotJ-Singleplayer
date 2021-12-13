using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[SerializeField] private float speed; //TESTING
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;
        
    private WeaponStats weaponStats; //TESTING
    [SerializeField] private GameObject Pistol; //TESTING

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        weaponStats = Pistol.GetComponent<WeaponStats>(); //TESTING
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = weaponStats.getBulletSpeed() * Time.deltaTime * direction; //TESTING
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Health>().TakeDamage(weaponStats.getBulletDamage());
        }
        else if (collision.tag == "Player") 
        {
            collision.GetComponent<Health>().TakeDamage(/*weaponStats.getBulletDamage()*/1);
        }
    }
    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}