using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    Rigidbody rb;
    GameObject playerBody;

    GameObject Camera;
    MouseLook turn;

    public bool key1;
    public bool key2;
    
    public float speed = 5;
    public int Health;

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


 
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key1")
        {
            key1 = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "Key2")
        {
            key2 = true;
            Destroy(other.gameObject);
        }


    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Health -= 5;
        }
    }
    
}
