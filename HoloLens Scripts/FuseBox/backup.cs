using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using UnityEngine;

public class backup : MonoBehaviour
{

    List<Vector3> SocketPos = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        GameObject socket1 = GameObject.Find("Socket1");

        SocketPos.Add(socket1.transform.position);


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        GameObject bladefuse = GameObject.Find("Blade Fuse");


        if (other.gameObject.tag == "fuse")
        {
            Behaviour manHandler = (Behaviour)GameObject.FindWithTag("fuse").GetComponent("ManipulationHandler");
            manHandler.enabled = false;
            bladefuse.transform.position = SocketPos[0];


        }

    }

}
