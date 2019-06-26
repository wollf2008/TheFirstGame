using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Lit or snuff the candle
 * Sparrow 6/24/2019
 */
public class Candle_State : MonoBehaviour
{
    GameObject light;
    bool if_lit = true;
    bool if_in_door = false;

    private void Start()
    {
        light = gameObject.transform.Find("Candle_Light").gameObject;
    }
    
    void Update()
    {
        if (if_lit && !if_in_door)
        {
            light.GetComponent<Light>().intensity = 10;
        }
        else if(!if_lit || if_in_door)
        {
            light.GetComponent<Light>().intensity = 0;
        }
    }

    public void Set_If_In_Door(bool if_in)
    {
        if_in_door = if_in;
    }
}