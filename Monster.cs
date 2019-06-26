using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Speed;
    public static bool availableLeft;
    float speed = 2f;
    Vector2 zero_velocity = new Vector2(0, 0);
    public GameObject monster;
    public GameObject player;

    GameObject col = null;

    //是否发现敌人
    public  bool Fplayer;

    //正常移动的转向和上下楼梯判定
    public bool openTheDoor;
    public bool goUpStairs;
    public bool goBack;
    public bool goTemplate;
    public bool goStairsBack;
    private int Templatenum;

    public GameObject Player;

    //追逐楼梯
    private bool show;
    private float absoffsety;
    private Vector3 shadow;
    private int start = 0;



    // Start is called before the first frame update
    void Start()
    {


        openTheDoor = true;
        goUpStairs = false;
        goBack = false;
        goTemplate = false;
        goStairsBack = false;
        Fplayer = true;
        Templatenum = 100;
        start = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //正常移动
            monster.layer = 9;

            //Moving on the ground
            if (col.tag == "Environment" || col.tag == "Door")
            {

                GetComponent<Rigidbody2D>().velocity = transform.right * speed;

            }
            //Moving on stairs
            else if (col.tag == "Stair")
            {
                if (col.transform.rotation.z < 0)
                {
                    GetComponent<Rigidbody2D>().velocity = (transform.right * 0.707f + transform.up * 0.707f) * speed;

                }
                else if (col.transform.rotation.z > 0)
                {

                    GetComponent<Rigidbody2D>().velocity = (transform.right * 0.707f - transform.up * 0.707f) * speed;

                }
            }

            //索敌移动
        if (Fplayer == true)
        {
            float offsetx;
            float offsety;

            //得到相对于玩家的位置
            offsety = player.transform.position.y - transform.position.y;
            absoffsety = System.Math.Abs(player.transform.position.y - transform.position.y);
            offsetx = player.transform.position.x - player.transform.position.x;

            /*追踪上楼梯||电梯的4个歩奏*/
            //确定玩家使用了楼梯或电梯
            if (start == 0)
            {
                offsetx = player.transform.position.x - transform.position.x;
                if (absoffsety > 0.1 && absoffsety < 1)
                {
                    start = 1;

                }
                else if (absoffsety <= 0.1)
                {
                    goUpStairs = false;
                    goTemplate = false;
                }
                else if (absoffsety >= 1)
                {
                    start = 1;
                }
            }
            //确认玩家“消失”位置
            if(start == 1)
            {
                if (absoffsety > 0.1 && absoffsety < 1)
                {
                    shadow = player.transform.position;
                }
                else if (absoffsety >= 1)
                {
                    shadow = player.transform.position;
                }
                start = 2;
            }
            //走向玩家“消失”位置
            if(start == 2)
            {
                offsetx = shadow.x - transform.position.x;
                if (System.Math.Abs(offsetx)<=0.1)
                {
                    start = 3;
                }

            }
            //上（下）楼梯（电梯），然后返回正常状态
            if(start == 3)
            {
                if (absoffsety > 0.1 && absoffsety < 1)
                {
                    goUpStairs = true;
                }
                else if (absoffsety <= 0.1)
                {
                    goUpStairs = false;
                    goTemplate = false;
                }
                else if (absoffsety >= 1)
                {
                    goTemplate = true;
                    goUpStairs = true;
                }

                if (absoffsety < 0.1)
                {
                    start = 0;
                }
            }

            //转向玩家（残影）方向
            if (offsetx > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else if (offsetx <= 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }


        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //基本移动路径
        if (Fplayer == false)
        {
            if (other.gameObject.tag == "wall")
            {
                
                if (availableLeft == true)
                {
                    turnLeft();
                    
                }
                if (availableLeft == false)
                {
                    turnRight();                    
                }
            }


            if (other.gameObject.tag == "door")
            {
                openTheDoor = true;
            }
            if (other.gameObject.tag == "upstairs")
            {
                Upstairs();
            }
            if (other.gameObject.tag == "back")
            {
                Back();
            }
            if (other.gameObject.tag == "Door_Way")
            {
                Template();
            }
            if (other.gameObject.tag == "stairsback")
            {
                Stairsback();
            }
        }
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "door")
        {
            openTheDoor = true;
        }
        if (other.gameObject.tag == "upstairs")
        {
            goUpStairs = false;
        }
        if (other.gameObject.tag == "back")
        {
            goBack = false;
        }
        if (other.gameObject.tag == "Door_Way")
        {
            goTemplate = false;
        }
        if (other.gameObject.tag == "stairsback")
        {
            goStairsBack = false;
        }
    }

    void Upstairs()
    {
        //get a random number
        System.Random i = new System.Random();
        int num = i.Next(0, 100);
        if (num <= 30)
        {
            goUpStairs = true;
        }
        print("" + num);
    }
    void Back()
    {
        System.Random i = new System.Random();
        int num = i.Next(0, 100);
        if (num <= 15)
        {
            goBack = true;
        }
        if (goBack == true)
        {
            if (availableLeft == true)
            {
                turnLeft();
            }
            if (availableLeft == false)
            {
                turnRight();
            }
        }
    }
    void Template()
    {
            System.Random i = new System.Random();
            Templatenum = i.Next(0, 100);

        if (Templatenum <= 30)
        {
            goTemplate = true;
        }
    }

    void Stairsback()
    {
        System.Random i = new System.Random();
        int num = i.Next(0, 100);
        if (num <= 70)
        {
            goStairsBack = true;
        }
        if (goStairsBack == true)
        {
            if (availableLeft == true)
            {
                turnLeft();
            }
            if (availableLeft == false)
            {
                turnRight();
            }
        }
    }


    void turnLeft()
    {
        transform.eulerAngles = transform.eulerAngles - new Vector3(0, 180, 0);
    }
    void turnRight()
    {
        transform.eulerAngles = transform.eulerAngles - new Vector3(0, 180, 0);
        
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Environment" || other.gameObject.tag == "Stair")
        {
            col = other.gameObject;
        }
        if (other.gameObject.tag == "Stair")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Stair")
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 10;
        }
        if (other.gameObject.tag == "Environment" || other.gameObject.tag == "Stair")
        {
            col = null;
        }
    }
}
