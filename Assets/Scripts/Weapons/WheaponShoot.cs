using UnityEngine;

public class WheaponShoot : MonoBehaviour
{
    [SerializeField] private Transform firePoint; //fire position
    [SerializeField] private GameObject bullet; //projectile object
    public Transform gun; //gun object
    Vector2 direction; //mouse movement

    private PlayerMovement playerMovement;
    //private WeaponStats weaponStats;


    [SerializeField] private float BulletSpeed;
    [SerializeField] private float fireRate;

    float r4nextshot;
    


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        //weaponStats = GetComponentInChildren<WeaponStats>();
    }

    private void Update()
    {
        if (playerMovement.isFlip())
        {
            Vector2 mousePos = -Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePos + (Vector2)gun.position;
            FaceMouse();
        }
        else
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePos - (Vector2)gun.position;
            FaceMouse();
        }

        if (Input.GetMouseButton(0) /*&& weaponStats.canShoot() && playerMovement.canAttack()*/)
            if (Time.time > r4nextshot)
            {
                r4nextshot = Time.time + 1/fireRate;
                Attack();
            }            
    }

    private void FaceMouse() 
    {
        gun.transform.right= direction;
    }

    private void Attack() 
    {
        //weaponStats.setCooldownTimer();

        //bullets[FindBullet()].transform.position = firePoint.position;
        //bullets[FindBullet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));

        GameObject BulletIns = Instantiate(bullet, firePoint.position, firePoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right);

    }

    /*private int FindBullet() 
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)            
                return i;            
        }

        return 0;
    }*/

}
