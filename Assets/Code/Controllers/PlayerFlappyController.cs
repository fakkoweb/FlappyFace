using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFlappyController : MonoBehaviour
{
    public bool ControlActive;
    public float UpPush;
    public float ForwardPush;

    Gravitate grav = null;
    float currentAcceleration; // overrides gravity when needed
    float currentVelocity;
    float currentPositionY;
    bool impulseGiven;         // prevents altered acceleration to be considered more than one FixedUpdate

    // Use this for initialization
    void Start()
    {
        grav = GetComponent<Gravitate>();
        currentVelocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlActive && Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !impulseGiven)
        {
            // Override gravity and push up
            impulseGiven = true;
        }
    }

    void FixedUpdate()
    {
        if(GameManager.instance.IsGamePaused == false && grav != null)
        {
            currentAcceleration = grav.gConstant;
            if (impulseGiven)
            {
                // Override gravity and push up
                currentVelocity = 0;
                currentAcceleration = UpPush;
                impulseGiven = false;
            }

            float v_change = currentAcceleration * Time.deltaTime;      // (v0 +) a*t
            currentVelocity += v_change;
            float y_change = currentVelocity * Time.deltaTime;   // (y0 +) v*t
            transform.Translate(0, y_change, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ControlActive = false;
        Debug.LogError("hit");
        GameManager.instance.EndGame();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        ControlActive = false;
        GameManager.instance.EndGame();
    }

}
