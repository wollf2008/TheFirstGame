using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Pick up objects
 * The Object should be in the hand of the player
 * Sparrow 6/21/2019
 */
public class Hold_Object : MonoBehaviour
{
    public Transform hand;
    private Collider2D col = null;
    private GameObject object_sub = null;

    private bool if_object = false;
    private bool if_hold = false;
    
    void Update()
    {
        //Send the object to another layer to avoid collider conflict
        //Send it back when drop the object
        if(if_object && Input.GetKeyDown(KeyCode.Q) && if_hold == false)
        {
            if_hold = true;
            col.GetComponent<Rigidbody2D>().gravityScale = 0;//May need other way around
            object_sub = col.transform.Find("GameObject").gameObject;
            object_sub.layer = 11;
        }
        else if(if_object && Input.GetKeyDown(KeyCode.Q) && if_hold == true)
        {
            if_hold = false;
            col.GetComponent<Rigidbody2D>().gravityScale = 1;//May need other way around
            object_sub = col.transform.Find("GameObject").gameObject;
            object_sub.layer = 10;
        }
        if(if_hold)
        {
            col.GetComponent<Transform>().position = hand.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if((col.tag == "Object" || col.tag == "Candle") && if_hold == false)
        {
            if_object = true;
            this.col = col;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if ((col.tag == "Object" || col.tag == "Candle") && if_hold == false && this.col.Equals(col))
        {
            if_object = false;
            this.col = null;
        }
    }

    public Collider2D Get_Object()
    {
        return col;
    }
}
