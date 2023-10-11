using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // 创建一个三维向量, 用于平台移动
    private Vector3 _movement;

    // 控制平台移动速度
    public float speed;
    public GameObject topLine;

    void Start()
    {
        _movement.y = speed;
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += _movement * Time.deltaTime;
        if (transform.position.y >= topLine.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}