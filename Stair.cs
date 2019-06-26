using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Let the stair on or off the path of the player
 * Sparrow 6/22/2019
 */
public class Stair : MonoBehaviour
{
    public GameObject stair;
    public GameObject hide_ground;
    private bool playerup;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P1")
        {
            stair.layer = 10;
            hide_ground.layer = 0; //Also need to make the floor upstairs enabled
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.tag == "P1") && Input.GetKey(KeyCode.E))
        {
            stair.layer = 0;
            hide_ground.layer = 10; //Also need to make the floor upstairs disabled

        }
        else if ((other.tag == "P1") && other.gameObject.GetComponent<Monster>() == true)
        {
            if (other.gameObject.GetComponent<Monster>().goUpStairs == true)
            {
                hide_ground.layer = 10;
                stair.layer = 0;
            }
        }
    }
}

