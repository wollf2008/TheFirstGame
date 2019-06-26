using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//插件放在开的门的图像上

public class Door : MonoBehaviour
{
    //关着的门
    public GameObject doorclosed;
    public GameObject player;
    private int counter=0;


    private void Start()
    {
        
        GetComponent<SpriteRenderer>().enabled = false;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Monster>() == true)
        {
            if(other.gameObject.GetComponent<Monster>().openTheDoor == true)
            { 
            doorclosed.GetComponent<SpriteRenderer>().enabled = false;
            doorclosed.layer = 10/*与主角不关联的图层*/ ;
            GetComponent<SpriteRenderer>().enabled = true;
            counter = 0;
            }
            else if (other.gameObject.GetComponent<Monster>().openTheDoor == false)
            {
                Wait();

            }
        }
        else if (doorclosed.layer == 8/*与主角关联的图层*/ && Input.GetKey(KeyCode.P) && counter == 30)
        {
            doorclosed.GetComponent<SpriteRenderer>().enabled = false;
            doorclosed.layer = 10/*与主角不关联的图层*/ ;
            GetComponent<SpriteRenderer>().enabled = true;
            counter = 0;

        }
        else if (doorclosed.layer == 10 && Input.GetKey(KeyCode.P) && counter == 30)
        {
            doorclosed.GetComponent<SpriteRenderer>().enabled = true;
            doorclosed.layer = 8;
            GetComponent<SpriteRenderer>().enabled = false;
            counter = 0;
        }
        Counter();

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (doorclosed.layer == 8 && Input.GetKey(KeyCode.P) && counter == 30)
        {
            doorclosed.GetComponent<SpriteRenderer>().enabled = false;
            doorclosed.layer = 10;
            GetComponent<SpriteRenderer>().enabled = true;
            counter = 0;
        }
        else if (doorclosed.layer == 10 && Input.GetKey(KeyCode.P) && counter == 30)
        {
            doorclosed.GetComponent<SpriteRenderer>().enabled = true;
            doorclosed.layer = 8;
            GetComponent<SpriteRenderer>().enabled = false;
            counter = 0;
        }
        Counter();
    }
    private void OnTriggerStay2D(Collider2D other)
    {


        if (doorclosed.layer == 8 && Input.GetKey(KeyCode.P) && counter == 30)
        {
            doorclosed.GetComponent<SpriteRenderer>().enabled = false;
            doorclosed.layer = 10;
            GetComponent<SpriteRenderer>().enabled = true;
            counter = 0;
            if (player.transform.position.x > doorclosed.transform.position.x)/*Player at left*/
            {

            }
            if (player.transform.position.x <= doorclosed.transform.position.x)/*Player at right*/
            {

            }
        }
        else if (doorclosed.layer == 10 && Input.GetKey(KeyCode.P) && counter == 30)
        {
            doorclosed.GetComponent<SpriteRenderer>().enabled = true;
            doorclosed.layer = 8;
            GetComponent<SpriteRenderer>().enabled = false;
            counter = 0;
            if (player.transform.position.x > doorclosed.transform.position.x)/*Player at left*/
            {

            }
            if (player.transform.position.x <= doorclosed.transform.position.x)/*Player at right*/
            {

            }
        }
        Counter();


        
    }
    void Counter() { if (counter < 30) { counter++; } }
    public void Wait()
    {
        //开启携程RespawnCo
        StartCoroutine("RespawnCo");

    }
    public IEnumerator RespawnCo()
    {
        yield return new WaitForSecondsRealtime(5f);
        doorclosed.GetComponent<SpriteRenderer>().enabled = false;
        doorclosed.layer = 10/*与主角不关联的图层*/ ;
        GetComponent<SpriteRenderer>().enabled = true;
    }
}