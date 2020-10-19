using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Media;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ResetView : MonoBehaviour
{
    

    List<GameObject> gameObjects = new List<GameObject>();
    List<Vector3> gameObjectsLocation = new List<Vector3>();
    List<Vector3> gameObjectsRotation = new List<Vector3>();
    List<Vector3> gameObjectsScale = new List<Vector3>();



    // Start is called before the first frame update
    void Start()
    {
        AddObjectsToList();
        GetObjectsLocation();
        GetObjectsRotation();
        GetObjectsScale();

        Debug.Log(gameObjects[2]);
        Debug.Log(gameObjectsRotation[2]);
        Debug.Log(gameObjectsLocation[2]);
        Debug.Log(gameObjectsScale[2]);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResetTrainView()
    {
        int i = 0;
        Vector3 originalScale = new Vector3(100, 100, 100);
        

        foreach (GameObject z in gameObjects)
        {
            z.transform.position = gameObjectsLocation[i];
            z.transform.eulerAngles = gameObjectsRotation[i];
            z.transform.localScale = gameObjectsScale[i];
            i++;
        }
    }



    public void AddObjectsToList()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("TrainComponents"))
        {
            gameObjects.Add(o);
            
            
        }

    }

    public void GetObjectsLocation()
    {
        

        foreach (GameObject p in gameObjects)
        {
            gameObjectsLocation.Add(p.transform.position);
            

        }
    }

    public void GetObjectsRotation()
    {


        foreach (GameObject r in gameObjects)
        {
            gameObjectsRotation.Add(r.transform.eulerAngles);
            

        }
    }

    
    public void GetObjectsScale()
    {

        foreach (GameObject s in gameObjects)
        {
            gameObjectsScale.Add(s.transform.localScale);


        }
    }
}
