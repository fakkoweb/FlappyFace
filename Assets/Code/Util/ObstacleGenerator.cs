using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public float YShift;
    public float SpawnTime;
    public GameObject ObjectToSpawn;

    private GameObject lastObjectSpawn = null;

    // Use this for initialization
    void Start()
    {
        //FOR TESTING: StartGenerator();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void StopGenerator()
    {
        CancelInvoke("SpawnPipe");
    }

    public void StartGenerator()
    {
        InvokeRepeating("SpawnPipe", 0.2f, SpawnTime);
    }

    void SpawnPipe()
    {
        float resultY = Random.Range(-YShift, YShift);
        lastObjectSpawn = Instantiate(ObjectToSpawn, new Vector3(transform.position.x, resultY, 0), Quaternion.identity);
    }
}
