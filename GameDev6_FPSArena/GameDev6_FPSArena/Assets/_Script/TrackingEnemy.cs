using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingEnemy : MonoBehaviour {

    public Transform target;
    public GameObject playerCur;
    public Player player;
    Rigidbody rb;

    public float speed = 20;

    public bool TargetOn;
    public bool screamPlayed = false;


    public AudioSource[] audios;
    public AudioSource scream;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        playerCur = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = p.GetComponent<Player>();

        Chase();
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }

    public void Chase()
    {
        if(TargetOn)
        {
            Vector3 targetDir = target.position - transform.position;

            float step = speed * Time.deltaTime;

            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (!scream.isPlaying && !screamPlayed)
            {
                scream.Play();
                screamPlayed = true;
            }
        }
    }
}
