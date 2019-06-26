using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Send Player or Monster from one door to another
 * Sparrow 6/22/2019
 * 
 * Last change: Sparrow 6/24/2019
 */
public class Door_Way : MonoBehaviour
{
    public Transform connect_door;
    public Material[] mat = new Material[2];

    Collider2D collision;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "P1" && Input.GetKey(KeyCode.E))
        {
            this.collision = collision;
            collision.GetComponent<SpriteRenderer>().material = mat[1];
            if (collision.GetComponent<Hold_Object>().Get_Object() != null)
            {
                collision.GetComponent<Hold_Object>().Get_Object().GetComponent<SpriteRenderer>().material = mat[1];
                if(collision.GetComponent<Hold_Object>().Get_Object().tag == "Candle")
                {
                    collision.GetComponent<Hold_Object>().Get_Object().GetComponent<Candle_State>().Set_If_In_Door(true);
                }
            }
            Invoke("transfer", 0.5f);
        }
        else if ((collision.tag == "P1") && collision.gameObject.GetComponent<Monster>() == true)
        {
            
            if (collision.gameObject.GetComponent<Monster>().goTemplate == true)
            {
                this.collision = collision;
                collision.GetComponent<SpriteRenderer>().material = mat[1];
                Invoke("transfer", 0.5f);
            }
        }
    }

    private void transfer()
    {
        
        collision.transform.position = connect_door.position;
        Invoke("appear", 0.1f);
        collision.gameObject.GetComponent<Monster>().goTemplate = false;

    }

    //Add from transfer(): Sparrow 6/24/2019
    private void appear()
    {
        
        collision.GetComponent<SpriteRenderer>().material = mat[0];
        if (collision.GetComponent<Hold_Object>().Get_Object() != null)
        {
            collision.GetComponent<Hold_Object>().Get_Object().GetComponent<SpriteRenderer>().material = mat[0];
            if (collision.GetComponent<Hold_Object>().Get_Object().tag == "Candle")
            {
                collision.GetComponent<Hold_Object>().Get_Object().GetComponent<Candle_State>().Set_If_In_Door(false);
            }
        }
    }
}
