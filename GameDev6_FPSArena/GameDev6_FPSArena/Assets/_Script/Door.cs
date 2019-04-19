using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool inRange = false;
    public bool open = false;
    public bool locked = false;

    public bool Needkey = false;
    public bool doorPlayed = false;

    public Player keyCheck;

    public GameObject LeftDoor;
    public GameObject RightDoor;
    public float speed = 10.0f;


    public AudioSource[] audios;
    public AudioSource doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        openDoor();
        closeDoor();
        lockedDoor();
    }


   void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            inRange = false;

        }
    }

    void openDoor() {
        if (inRange && !open && !locked && !Needkey)
        {
                LeftDoor.transform.Translate(Vector3.left * speed * Time.deltaTime);
                RightDoor.transform.Translate(Vector3.right * speed * Time.deltaTime);
            if(RightDoor.transform.localPosition.x > 2.5)
            {
                open = true;
            }

            if(!doorOpen.isPlaying && !doorPlayed)
            {
                doorOpen.Play();
                doorPlayed = true;
            }
        }
    }

    void closeDoor()
    {
        if(!inRange && open)
        {
            LeftDoor.transform.Translate(Vector3.left * -speed * Time.deltaTime);
            RightDoor.transform.Translate(Vector3.right * -speed * Time.deltaTime);

            if(RightDoor.transform.localPosition.x < 1.25)
            {
                open = false;
                doorPlayed = false;
            }
        }
        
    }

    void lockedDoor()
    {
        if (Needkey)
        {
            if(keyCheck.key1 && keyCheck.key2)
            {
                Needkey = false;
            }
        }
    }
}
