using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : Weapon
{
    //Variables
    [Header("Bullet Settings")]
    public Projectile bulletPrefab;     //The bullet to shoot
    public Transform barrel;            //Where to shoot from
    public bool triggerPulled;          //If we're shooting
    public float muzzleVelocity;        //How fast to shoot
    private float timeNextShotIsReady;  //If we can shoot yet
    public float shotsPerMinute;        //How many shots per minute
    public float spread;                //The bullet spread
    public float projectileCount;       //How many shots at once
    private ParticleSystem muzzleFlashParticle;

    [Header("Audio Settings")]
    public AudioClip firingSound;        //The sound made when firing
    private AudioSource audioSource;     //The AudioSouce Components

    private void Awake()
    {
        //Set the time
        timeNextShotIsReady = Time.time;
        audioSource = GetComponent<AudioSource>();
        muzzleFlashParticle = GetComponentInChildren<ParticleSystem>();
    }

    protected void Update()
    {
        Shoot();
    }

    public void PullTrigger()
    {
        triggerPulled = true;
    }

    public void ReleaseTrigger()
    {
        triggerPulled = false;
    }

    protected virtual void Shoot()
    {
        //If they pull the trigger
        if (triggerPulled)
        {
            //If they waited the time to shoot
            while (Time.time > timeNextShotIsReady)
            {
                //Shoot all of the bullets
                for (int index = 0; index < projectileCount; index++)
                {
                    //Play Particle
                    muzzleFlashParticle.Emit(1);
                    //Spawn a projectile
                    Projectile projectile = Instantiate(bulletPrefab, barrel.position, barrel.rotation * Quaternion.Euler(Random.onUnitSphere * spread)) as Projectile;
                    //Set damage 
                    projectile.damage = damage;
                    //Set layer
                    projectile.gameObject.layer = gameObject.layer;
                    //Add a force to it
                    projectile.rb.AddRelativeForce(Vector3.forward * muzzleVelocity, ForceMode.VelocityChange);
                    //Play Sound
                    if (audioSource)
                    {
                        audioSource.PlayOneShot(firingSound);
                    }
                }
                //Reset shot time
                timeNextShotIsReady += 60f / shotsPerMinute;
            }
        }
        else if (Time.time > timeNextShotIsReady)
        {
            //Keep track of time while they aren't shooting
            timeNextShotIsReady = Time.time;
        }
    }

}
