using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    // 列表用于存储所有需要生成的平台
    public List<GameObject> platforms = new List<GameObject>();

    // 生成平台的间隔时间
    public float spawnTime = 0.5f;

    // 用于记录时间
    private float _spawnTimer;

    // 生成物体的位置
    private Vector3 _spawnPosition;


    void Update()
    {
        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        _spawnTimer += Time.deltaTime;
        _spawnPosition = transform.position;
        _spawnPosition.x = Random.Range(-3f, 3f);
        if (_spawnTimer >= spawnTime)
        {
            CreatePlatform();
            _spawnTimer = 0;
        }
    }

    public void CreatePlatform()
    {
        int index = Random.Range(0, platforms.Count);

        Instantiate(platforms[index], _spawnPosition, Quaternion.identity, transform);
    }
}