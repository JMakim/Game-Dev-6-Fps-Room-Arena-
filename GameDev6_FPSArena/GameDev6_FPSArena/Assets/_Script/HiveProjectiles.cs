using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveProjectiles : MonoBehaviour {
    public HiveGun hiveGun;
    public Transform target;
    public GameObject targetCur;
    Rigidbody rb;

    public float hit= 3;
    public float speed = 20;
    public bool targetFound;
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //GameObject p = GameObject.FindGameObjectWithTag("TargetLock");
        targetCur = GameObject.FindGameObjectWithTag("TargetLock");
        target = GameObject.FindGameObjectWithTag("TargetLock").transform;


           
        if(targetCur != null)
        {
            targetFound = true;

        }



        attack();

        if (hit <= 0)
        {
            
            Destroy(this.gameObject);
            hiveGun.hiveCount--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            hit -= 1;
        }
    }

    void attack()
    {
        if (targetFound)
        {
            Vector3 targetDir = target.position - transform.position;

            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }
}
