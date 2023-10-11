using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    private LineRenderer _line;

    // 初始点和结束点位置
    public Transform startPoint;
    public Transform endPoint;

    void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        _line.SetPosition(0, startPoint.position);
        _line.SetPosition(1, endPoint.position);
    }
}