using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Move one object will affect the other side
 */
public class Mirror_Moving : MonoBehaviour
{
    public Transform object_bro;

    void Update()
    {
        float x = -transform.position.x;
        float y = transform.position.y;
        Vector3 new_position = new Vector3(x, y, 0f);
        object_bro.position = new_position;
    }


}
