using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    Rigidbody rb;
    GameObject playerBody;

    GameObject Camera;
    MouseLook turn;

    public bool key1;
    public bool key2;
    public bool moving;
    public bool win;
    public bool yayPlayed = false;
    
    public float speed = 5;
    public float Health;
    public float MaxHealth = 100;

    public Text healthText;

    public Slider healthSlider;

    public GameObject pause;
    public GameObject victory;
    public GameObject lose;

    public AudioSource[] audios;
    public AudioSource move;
    public AudioSource yay;

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
        textHealth();
        MoveSound();

        if (win)
        {
            victory.SetActive(true);
            if (!yay.isPlaying && !yayPlayed)
            {
                yay.Play();
                yayPlayed = true;
            }
            Time.timeScale = 0;

        }
	}

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            moving = true;   
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            moving = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            moving = true;
        }

        

    }

    void MoveSound()
    {
        if (moving && !move.isPlaying)
        {
            move.Play();
        }
        if (move.isPlaying && Input.GetKeyUp(KeyCode.A))
        {
            move.Stop();
            moving = false;
        }
        if (move.isPlaying && Input.GetKeyUp(KeyCode.D))
        {
            move.Stop();
            moving = false;
        }
        if (move.isPlaying && Input.GetKeyUp(KeyCode.S))
        {
            move.Stop();
            moving = false;
        }
        if (move.isPlaying && Input.GetKeyUp(KeyCode.W))
        {
            move.Stop();
            moving = false;
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
        if (other.gameObject.tag == "Enemy2")
        {
            Health -= 10;
        }
        if (other.gameObject.tag == "Win")
        {
            win = true;
        }
    }

    void textHealth()
    {
        healthText.text = "Health: " + Health;
        healthSlider.value = Health;
    }
    
}
