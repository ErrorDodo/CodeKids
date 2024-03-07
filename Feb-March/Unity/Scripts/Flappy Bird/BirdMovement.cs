using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float flapForce;

    [SerializeField] 
    private LogicManager logicManager;

    private bool birdAlive = true;

    private void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdAlive)
        {
            rb.velocity = Vector2.up * flapForce;
        }
        BelowCamera();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        logicManager.GameOver();
        birdAlive = false;
    }
    
    private void BelowCamera()
    {
        if (transform.position.y is < -6 or > 6)
        {
            logicManager.GameOver();
            birdAlive = false;
        }
    }
}
