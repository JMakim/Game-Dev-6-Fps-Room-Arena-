using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public float lookSpeed = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lookX();
        //lookY();
	}

    void lookX()
    {
        float rotateX = lookSpeed * Input.GetAxis("Mouse Y");
        rotateX *= Time.deltaTime;
        transform.Rotate(-rotateX, 0, 0);
    }

}
