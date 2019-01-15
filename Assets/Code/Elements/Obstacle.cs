using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float MovingSpeed;
    public float Gap;
    public GameObject topObstacle;
    public GameObject bottomObstacle;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        topObstacle.transform.Translate(0, Gap, 0);
        bottomObstacle.transform.Translate(0, -Gap, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.instance.IsGamePaused == false)
            transform.Translate(-MovingSpeed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "ObstacleDestroyer")
        {
            Destroy(gameObject);
        }
    }
}
