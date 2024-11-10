// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using System;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float normalSpeed = 3f;
    public float maxSpeed = 6f;
    public float accelerationRate = 0.1f;
    public float boostMultiplier = 10f;

    private float currentSpeed;
    private float rotationX = 0f;

    public int health = 100;

    private Transform myTransform;
    private Vector3 initialPosition;

    private void Awake()
    {
        myTransform = transform;
        currentSpeed = normalSpeed;
        initialPosition = myTransform.position;
    }

    public void FixedUpdate()
    {
        HandleMovementInput();
        ApplyRotation();
        AutoAccelerate();
        ReturnToInitialPosition();
    }

    private void HandleMovementInput()
    {
        float moveDirection = Input.GetKey(KeyCode.D) ? 0.8f : Input.GetKey(KeyCode.A) ? -0.8f : 0f;
        
        if (myTransform.position.x + moveDirection > -14 && myTransform.position.x + moveDirection < 1)
        {
            myTransform.position += new Vector3(moveDirection, 0, 0);
            rotationX = Mathf.Lerp(rotationX, moveDirection * -50f, Time.deltaTime * rotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed = normalSpeed * boostMultiplier;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            currentSpeed = normalSpeed;
        }
        
        myTransform.position += myTransform.forward * currentSpeed * Time.deltaTime; 
    }

    private void AutoAccelerate()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += accelerationRate * Time.deltaTime;
        }
    }

    private void ApplyRotation()
    {
        rotationX = Mathf.Lerp(rotationX, 0f, Time.deltaTime * rotationSpeed);
        myTransform.rotation = Quaternion.Euler(0, 0, rotationX);
    }
    
    private void ReturnToInitialPosition()
    {
        myTransform.position = Vector3.Lerp(myTransform.position, initialPosition, Time.deltaTime * accelerationRate);
    }

    public void OnRelease()
    {
        gameObject.SetActive(false);
    }
}