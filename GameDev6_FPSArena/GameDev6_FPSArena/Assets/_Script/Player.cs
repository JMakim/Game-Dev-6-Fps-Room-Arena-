using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    Rigidbody rb;
    GameObject playerBody;

    GameObject Camera;
    MouseLook turn;

    public float speed = 5;

	// Use this for initialization
	void Start () {
        if (!playerBody)
        {
            playerBody = GameObject.FindGameObjectWithTag("Player");
        }
        rb = GetComponent<Rigidbody>();

        Camera = GameObject.Find("FirstPersonCamera");
        turn = Camera.GetComponent<MouseLook>();

    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        lookY();

        if (Input.GetKey(KeyCode.R))
        {
          
            SceneManager.LoadScene("TestingRoom");
        }
	}

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
         
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
          
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
         
        }

        

    }

    void lookY()
    {
       float rotateY = turn.lookSpeed * Input.GetAxis("Mouse X");
       rotateY *= Time.deltaTime;
       transform.Rotate(0, rotateY, 0);
    }
    
    
}
