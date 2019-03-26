using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{

    public Door doorNorth;
    public Door doorWest;
    public Door doorEast;
    public Door doorSouth;

    public Collider other;
    public bool lockDoor = false;
    public bool enemyCount = false;
    public bool playerEnter = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RoomLock();

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
        }
        if(other.tag == "Enemy")
        {
            enemyCount = true;
            this.other = other;
        }
    }

    void RoomLock()
    {
        if(playerEnter && enemyCount)
        {
            doorNorth.locked = true;
            doorWest.locked = true;
            doorEast.locked = true;
            doorSouth.locked = true;
        }
    }
}
