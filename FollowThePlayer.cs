
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePlayer : MonoBehaviour
{

    public Transform PlayerPosition;//跟踪的对象
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        //         当前位置              物体的位置
        offset = transform.position - PlayerPosition.position;//计算相对距离
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerPosition.position + offset; //保持相对距离
    }

}