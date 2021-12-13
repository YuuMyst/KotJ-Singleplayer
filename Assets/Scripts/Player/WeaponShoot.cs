using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    //SerializeField - see PlayerMovement
    //Pooling - reusable world objects instead of creating new instances
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] bullets; //array stores all fireball objects

    //Object references
    private PlayerMovement playerMovement;
    private WeaponStats weaponStats;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        weaponStats = GetComponentInChildren<WeaponStats>();        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && weaponStats.canShoot() && playerMovement.canAttack())
            Attack();
    }

    private void Attack() 
    {
        weaponStats.setCooldownTimer();

        bullets[FindBullet()].transform.position = firePoint.position;
        bullets[FindBullet()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindBullet() 
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
        }

        return 0;
    }

}
