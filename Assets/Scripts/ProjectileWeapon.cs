using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    //Variables
    [Header("Bullet Settings")]
    public Projectile bulletPrefab;
    public Transform barrel;
    public bool triggerPulled;
    public float muzzleVelocity;
    private float timeNextShotIsReady;
    public float shotsPerMinute;
    public float spread;
    public float projectileCount;

    private void Awake()
    {
        timeNextShotIsReady = Time.time;
    }

    private void Update()
    {
        if (triggerPulled)
        {
            while (Time.time > timeNextShotIsReady)
            {
                for (int index = 0; index < projectileCount; index++)
                {
                    // Spawn a projectile
                    Projectile projectile = Instantiate(bulletPrefab, barrel.position, barrel.rotation * Quaternion.Euler(Random.onUnitSphere * spread)) as Projectile;
                    projectile.damage = damage;
                    projectile.gameObject.layer = gameObject.layer;
                    projectile.rb.AddRelativeForce(Vector3.forward * muzzleVelocity, ForceMode.VelocityChange);
                }
                timeNextShotIsReady += 60f / shotsPerMinute;
            }
        }
        else if (Time.time > timeNextShotIsReady)
        {
            timeNextShotIsReady = Time.time;
        }
    }

    public void PullTrigger()
    {
        triggerPulled = true;
    }

    public void ReleaseTrigger()
    {
        triggerPulled = false;
    }

}
