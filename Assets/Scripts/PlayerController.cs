using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 角色刚体组件对象
    private Rigidbody2D _rigidbody2D;

    // 角色动画组件对象
    private Animator _animator;

    // 获取角色横轴移动的值
    private float _xVelocity;

    // 角色移动速度
    public float speed = 5.0f;

    // 判断角色是否死亡
    private bool _playerDead;


    // 判断角色是否踩在平台上
    private bool _isOnGround;

    // 检测范围
    public float checkRadius;

    // 检测图层
    public LayerMask platform;

    // 检测平台的物体
    public GameObject groundCheck;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, platform);

        // idle, run, fall 之间的动画状态切换
        _animator.SetBool("isOnGround", _isOnGround);

        Movement();
    }

    // 控制角色移动以及动画切换
    private void Movement()
    {
        _xVelocity = Input.GetAxisRaw("Horizontal");

        _rigidbody2D.velocity = new Vector2(_xVelocity * speed, _rigidbody2D.velocity.y);

        // idle, run 之间的动画状态切换  
        _animator.SetFloat("speed", Mathf.Abs(_rigidbody2D.velocity.x));

        if (_xVelocity != 0)
        {
            transform.localScale = new Vector3(_xVelocity, 1, 1);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        // 当碰撞到的物体的 tag 是 Spike 时, 播放死亡动画
        if (other.gameObject.CompareTag("Spike"))
        {
            _animator.SetTrigger("dead");
            
        }

        // 当碰撞到的物体的 tag 是 Fan 时, 使角色可以被弹起来
        if (other.gameObject.CompareTag("Fan"))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 10f);
        }
    }

    // 在角色死亡动画最后一帧添加event
    public void PlayerDead()
    {
        _playerDead = true;
        GameManager.GameOver(_playerDead);
    }

    // 显示射线的范围
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkRadius);
    }
}