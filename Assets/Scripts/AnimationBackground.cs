using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBackground : MonoBehaviour
{
    // 背景的移动速度
    public Vector2 speed;

    // 背景的材质
    private Material _material;

    // 通过_movement来调整背景材质的offset
    private Vector2 _movement;


    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame

    void Update()
    {
        _movement += speed * Time.deltaTime;
        _material.mainTextureOffset = _movement; 
    }
}