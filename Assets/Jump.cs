using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump: FPSInput
{
    public GameObject player;
    
    public int jumpSpeed = 50;

    void Start()
    {
        player = (GameObject)this.gameObject;
    }
    void Update()
    {
       
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 movement = new Vector3(0, jumpSpeed*Time.deltaTime, 0);
        }
    }
}