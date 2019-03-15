using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheck : MonoBehaviour {

    public GameObject Track;
    TrackingEnemy check;


	// Use this for initialization
	void Start () {

        check = Track.GetComponent<TrackingEnemy>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            check.TargetOn = true;
            Debug.Log("Track On");
        }
    }
}
