using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Contral player moving left right and up stairs
 * Sparrow 6/21/2019
 * 
 * Last change: Sparrow 6/22/2019
 */
public class Moving : MonoBehaviour
{
    float speed = 3f;
    Vector2 zero_velocity = new Vector2(0, 0);

    GameObject col = null;

    void Start()
    {
        
    }
    
    void Update()
    {

        //print(col.collider.tag);
        //Moving on the ground
        if (col.tag == "Environment" || col.tag == "Door")
        {
            if (Input.GetKey(KeyCode.A))
            {
                GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                GetComponent<Rigidbody2D>().velocity = transform.right * speed;
            }
        }
        //Moving on stairs
        else if(col.tag == "Stair")
        {
            if(col.transform.rotation.z < 0)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    GetComponent<Rigidbody2D>().velocity = -(transform.right * 0.707f + transform.up * 0.707f) * speed;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    GetComponent<Rigidbody2D>().velocity = (transform.right * 0.707f + transform.up * 0.707f) * speed;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = zero_velocity;
                }
            }
            else if (col.transform.rotation.z > 0)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    GetComponent<Rigidbody2D>().velocity = -(transform.right * 0.707f - transform.up * 0.707f) * speed;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    GetComponent<Rigidbody2D>().velocity = (transform.right * 0.707f - transform.up * 0.707f) * speed;
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = zero_velocity;
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Environment" || other.gameObject.tag == "Stair")
        {
            col = other.gameObject;
        }
        if(other.gameObject.tag == "Stair")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Stair")
        {
            GetComponent<Rigidbody2D>().gravityScale = 10;
        }
        if(other.gameObject.tag == "Environment" || other.gameObject.tag == "Stair")
        {
            col = null;
        }
    }
}
