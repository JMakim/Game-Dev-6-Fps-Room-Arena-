using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTesting : MonoBehaviour {

    public GameObject lockTarget;

    public float health = 10;
    public float LockTime = 0;
    public bool lockedOn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //HiveHit();

        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
        if(LockTime >= 3)
        {
            lockedOn = true;
        }
        if (lockedOn)
        {
            lockTarget.SetActive(true);
        }
	}

    void HiveHit()
    {
        Debug.Log("Hive Hit");
    }

    public void Damage(float damageAmount)
    {
        LockTime += damageAmount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "HIVE")
        {
            health -= 1;
        }
    }




}
