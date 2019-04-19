using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{

    public Door doorNorth;
    public Door doorWest;
    public Door doorEast;
    public Door doorSouth;

    public GameObject Lights;

    public Collider other;
    public bool lockDoor = false;
    public bool enemyCount = false;
    public bool playerEnter = false;
    public bool lightPlay = false;

    public AudioSource[] audios;
    public AudioSource lightsON;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      


        if(playerEnter && !other)
        {
            enemyCount = false;
            doorNorth.locked = false;
            doorWest.locked = false;
            doorEast.locked = false;
            doorSouth.locked = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerEnter = true;
            if (!lightsON.isPlaying && !lightPlay)
            {
                lightsON.Play();
                lightPlay = true;
            }
            Lights.SetActive(true);
        }
        if(other.tag == "Enemy")
        {
            enemyCount = true;
            this.other = other;
        }    
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Lights.SetActive(false);
            playerEnter = false;
            lightPlay = false;
        }
    }

  

   


}
