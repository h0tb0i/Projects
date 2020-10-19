using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Reset : MonoBehaviour
{
    Vector3 initPos = new Vector3();
    private GameObject fuse;

    // Start is called before the first frame update
    void Start()
    {
        fuse = GameObject.Find("Blade Fuse");
        initPos = fuse.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetFuse()
    {
        fuse.transform.position = initPos;
        Behaviour manHandler = (Behaviour)GameObject.FindWithTag("fuse").GetComponent("ManipulationHandler");
        manHandler.enabled = true;
        GameObject.Find("Blade_Fuse").GetComponent<Renderer>().material.color = Color.grey;
    }
}
