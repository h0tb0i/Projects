using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ChangeScene : MonoBehaviour
{

    List<GameObject> gameObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        AddObjectsToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObjectsToList()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Stage1Components"))
        {
            gameObjects.Add(o);


        }

    }

    public void EnableDisable()
    {

        Task delay = Task.Delay(5000);

        foreach (GameObject o in gameObjects)
        {
            if (o.activeSelf == true)
            {
                o.SetActive(false);
                
            }
            else
            {
                o.SetActive(true);
            }

            
        }

    }

    public void ChangeView() {


        EnableDisable();
        
    }
        
}
