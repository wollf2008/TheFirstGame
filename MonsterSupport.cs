using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSupport : MonoBehaviour
{
    public bool leftside;
    public bool rightside;


    // Start is called before the first frame update
    void Start()
    {
        if (leftside == true)
        {
            rightside = false;
        }
        if (rightside == true)
        {
            leftside = false;
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall" || other.gameObject.tag == "back" || other.gameObject.tag == "stairsback")
        {
            if (leftside == true && rightside == false)
            {
                Monster.availableLeft = false;

            }
            if (leftside == false && rightside == true)
            {
                Monster.availableLeft = true;

            }
        }
    }

}
