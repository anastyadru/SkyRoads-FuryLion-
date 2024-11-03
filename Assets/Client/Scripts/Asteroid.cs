// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float asteroidSpeed;
    public float rotationSpeed = 30f;
    
    private Rigidbody rb;
    private Transform myTransform;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myTransform = transform;
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector3(0f, 0f, asteroidSpeed));
        rb.AddTorque(myTransform.forward * rotationSpeed);
    }

    public void Update()
    {
        asteroidSpeed -= 5f * Time.deltaTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            Destroy(gameObject);
            return;
        }
        
        FindObjectOfType<ScoreManager>().AddAsteroidScore();
    }
}