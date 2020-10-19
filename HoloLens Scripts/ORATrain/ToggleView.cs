using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ToggleView : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleTrainView()
    {

        //bool isObjectActive = this.gameObject.activeSelf;

        bool active = this.gameObject.activeSelf;
       
        if (active == false)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        

    }
}

