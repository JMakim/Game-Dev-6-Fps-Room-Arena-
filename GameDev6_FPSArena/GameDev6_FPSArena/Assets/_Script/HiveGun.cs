﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveGun : MonoBehaviour {

    public Transform gunEnd;
    public LineRenderer laserLine;
    public Camera fpsCam;

    public GameObject hiveProjectile;

    private float nextFire;
    public float fireRate = .25F;
    public float weaponRange = 100;
    public float gunDamage = 1;



    public int hiveCount = 0;
	// Use this for initialization
	void Start () {
        laserLine = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        fire();
        createLine();
        spawnHive();
    }

    void fire()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            laserLine.enabled = true;

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));

            RaycastHit hit;


            laserLine.SetPosition(0, gunEnd.position);

            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
            {
                laserLine.SetPosition(1, hit.point);
                WeaponTesting health = hit.collider.GetComponent<WeaponTesting>();
                HiveProjectiles target = hit.collider.GetComponent<HiveProjectiles>();
                if(health != null)
                {
                    health.Damage(gunDamage);
                }

                
            }
            else
            {
                laserLine.SetPosition(1, fpsCam.transform.forward * weaponRange);
            }

        }
        if (Input.GetButtonUp("Fire1"))
        {
            laserLine.enabled = false;
        }
    }

    void spawnHive()
    {
        if (Input.GetButton("Fire2") && hiveCount<5)
        {
            Instantiate(hiveProjectile, transform.position,transform.rotation);
            hiveCount++;
        }

        if (Input.GetKey(KeyCode.R))
        {
            hiveCount = 0;
        }
    }

    void createLine()
    {

        Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        Debug.DrawRay(lineOrigin, fpsCam.transform.forward * weaponRange, Color.green);
    }
}
