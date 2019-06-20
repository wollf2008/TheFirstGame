using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    private GameObject camera0;
    private GameObject camera1;
    private GameObject camera2;
    private GameObject camera3;

    void Start()
    {
        camera0 = GameObject.Find("Real_World");
        camera1 = GameObject.Find("Mirror_World");
        camera2 = GameObject.Find("Real_World_Map");
        camera3 = GameObject.Find("Mirror_World_Map"); 
        camera2.SetActive(false);
        camera3.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            camera0.SetActive(false);
            camera2.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            camera2.SetActive(false);
            camera0.SetActive(true);
            
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            camera1.SetActive(false);
            camera3.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            camera3.SetActive(false);
            camera1.SetActive(true);
        }

    }

  

}
