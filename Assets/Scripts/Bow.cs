using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Bow : MonoBehaviour
{
    public Transform muzzle;
    public Projectile projectile;
    public float msbetweenShots = 5f;
    public float muzzleVelocity = 35;

    float nextShotTime;
    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msbetweenShots / 1000;
            Projectile newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as Projectile;
            newProjectile.Setspeed(muzzleVelocity);
        }
   
    }
}
