//using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;

public class OnCollision : MonoBehaviour
{


    List<Vector3> SocketPos = new List<Vector3>();
    List<Vector3> BladeRot = new List<Vector3>();

    //Sockets that will respond positively to a collision with the Blade Fuse
    public string correctSocket = "Socket";
    public string correctSocket2 = "Socket";
    public string correctSocket3 = "Socket";


    int rnd = new int();


    // Start is called before the first frame update
    void Start()
    {

        //Adding the vector location of each socket to the SocketPos List
        SocketPos.Add(GameObject.Find("Socket0").transform.position);
        SocketPos.Add(GameObject.Find("Socket1").transform.position);
        SocketPos.Add(GameObject.Find("Socket2").transform.position);
        SocketPos.Add(GameObject.Find("Socket3").transform.position);
        SocketPos.Add(GameObject.Find("Socket4").transform.position);
        SocketPos.Add(GameObject.Find("Socket5").transform.position);

        //Adds the original rotation of the Blade fuse to the BladeRot List
        BladeRot.Add(GameObject.Find("Blade Fuse").transform.eulerAngles);

        //Generates a random number and applies it to the correct socket string
        RandNum();

        

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Checks for collisions of objects with Box Colliders
    void OnTriggerEnter(Collider other)
    {
        GameObject bladefuse = GameObject.Find("Blade Fuse");


        //If the object collided with is a pre-defined socket, it will place it at the correct location and rotation for the socket
        if (other.gameObject.name == "Socket0")
        {
            DisableFuse();
            bladefuse.transform.position = SocketPos[0];


        }
        else if (other.gameObject.name == "Socket1")
        {
            DisableFuse();
            bladefuse.transform.position = SocketPos[1];

        }
        else if (other.gameObject.name == "Socket2")
        {
            DisableFuse();
            bladefuse.transform.position = SocketPos[2];

        }
        else if (other.gameObject.name == "Socket3")
        {
            DisableFuse();
            bladefuse.transform.position = SocketPos[3];

        }
        else if (other.gameObject.name == "Socket4")
        {
            DisableFuse();
            bladefuse.transform.position = SocketPos[4];

        }
        else if (other.gameObject.name == "Socket5")
        {
            DisableFuse();
            bladefuse.transform.position = SocketPos[5];

        }
        //If the socket is correct, play the 'ding' and change the fuse to a green colour
        if (other.gameObject.name == correctSocket || other.gameObject.name == correctSocket2 || other.gameObject.name == correctSocket3)
        {
            Debug.Log("You were Correct!");
            GameObject.Find("FuseBox").GetComponent<AudioSource>().Play();
            GameObject.Find("Blade_Fuse").GetComponent<Renderer>().material.color = Color.green;
        }
        //If the socket is not the correct socket, it will play the 'explosion' sound and start the animations for sparks
        else if (other.gameObject.name != correctSocket || other.gameObject.name != correctSocket2 || other.gameObject.name != correctSocket3)
        {
            if (other.gameObject.name == "Socket0" || other.gameObject.name == "Socket1" || other.gameObject.name == "Socket2" || other.gameObject.name == "Socket3" || other.gameObject.name == "Socket4" || other.gameObject.name == "Socket5")
            {
                
                GetComponent<AudioSource>().Play();

                //Begins the animation for the sparks explosion
                GameObject.Find("Particle System").transform.position = bladefuse.transform.position;
                GameObject.Find("Particle System2").transform.position = bladefuse.transform.position;
                GameObject.Find("Particle System").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Particle System2").GetComponent<ParticleSystem>().Play();
                GameObject.Find("Blade_Fuse").GetComponent<Renderer>().material.color = Color.black;
            }

        }

        correctSocket = "Socket";
    }

    public void RandNum()
    {
        rnd = Random.Range(0, 5);
        correctSocket = "Socket" + rnd.ToString();

        rnd = Random.Range(0, 5);
        correctSocket2 = "Socket" + rnd.ToString();

        rnd = Random.Range(0, 5);
        correctSocket3 = "Socket" + rnd.ToString();

        if (correctSocket2 == correctSocket)
        {
            rnd = Random.Range(0, 5);
            correctSocket2 = "Socket" + rnd.ToString();
        }

        if (correctSocket3 == correctSocket || correctSocket3 == correctSocket2)
        {
            rnd = Random.Range(0, 5);
            correctSocket3 = "Socket" + rnd.ToString();
        }
    }

    void DisableFuse()
    {
        Behaviour manHandler = (Behaviour)GameObject.FindWithTag("fuse").GetComponent("ManipulationHandler");
        manHandler.enabled = false;
        GameObject.Find("Blade Fuse").transform.eulerAngles = BladeRot[0];

    }



}
