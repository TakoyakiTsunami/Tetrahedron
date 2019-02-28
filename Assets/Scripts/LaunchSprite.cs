﻿// MoveRotation
// The sprite is set a rotation speed.

using UnityEngine;
using System.Collections;

public class LaunchSprite : MonoBehaviour
{
    public enum CharacterState
    {
        Landed,
        Launchable, // Switch Launchable to Launching
        InAir
    }

    private CharacterState state;

    private Rigidbody2D rb;

    public float thrust = 1;
    private float rotation = 5.0f;
    private float thrustLimit = 100;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = CharacterState.Launchable;

    }

    void Update()
    {
        if (state == CharacterState.Launchable && Input.GetKey(KeyCode.Space) && thrust < thrustLimit)
        {
            thrust += Time.deltaTime * 5;
            Debug.Log("Power: " + thrust);
        }


        // Cancel launching 
        if (state == CharacterState.Launchable && Input.GetKey(KeyCode.LeftShift))
        {
            state = CharacterState.Landed;
            Debug.Log("ABORT LAUNCHING!" + state);
        }

        if (state == CharacterState.Launchable && Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrust);
            state = CharacterState.InAir;
        }

        else if (Input.GetAxis("Horizontal") != 0.0f)
        {
            // TODO LIST
            // Figure out how to handle rotation (which character states?)
            // Include a power bar above the character when you are launching
            // Depending on the thrust, it will fill up
            // When you abort, the spacebar will disappear
            // Look up a tutorial for it; 

            Vector3 tempRotation = gameObject.transform.rotation.eulerAngles;

            // gameObject refers to object this script is attached to
            gameObject.transform.rotation = Quaternion.Euler(tempRotation.x, tempRotation.y, tempRotation.z + (rotation * Input.GetAxis("Horizontal")));
        }
    }

    public CharacterState getState()
    {
        return state;
    }

    public void setState(CharacterState NewState)
    {
        state = NewState;
    }
}