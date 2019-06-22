using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public float speed = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 

        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {

            GetComponent<Rigidbody2D>().velocity = new Vector2 (0,0);
        }

        else if (Input.GetKeyUp(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

}
