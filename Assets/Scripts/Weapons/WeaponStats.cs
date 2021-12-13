using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] private float weaponCooldown;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;

    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    public float getFireSpeed() { return weaponCooldown; }

    public float getBulletSpeed() { return bulletSpeed; }

    public float getBulletDamage() { return bulletDamage; }

    public void setCooldownTimer() { cooldownTimer = 0; }
    public bool canShoot() {
        if (cooldownTimer > weaponCooldown)
            return true;
        else
            return false;
    }

}
