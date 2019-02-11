// MoveRotation
// The sprite is set a rotation speed.

using UnityEngine;
using System.Collections;

public class LaunchSprite : MonoBehaviour
{
    private Rigidbody2D rb;

    public float rotation = 5.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
    
        rotation += Input.GetAxis("Horizontal");
        Quaternion sprite = Quaternion.Euler(0, 0, rotation);

        // gameObject refers to object this script is attached to
        // Thus, there's no need for GetComponent
        gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, sprite, Time.deltaTime);


    }


    // LAUNCHING PHYSICS
    // When you press spacebar, add a force to rigidbody 2D
    // Force must be in a direction towards what it's ortated at

    // Whenever you press the launch button, take the rotation of the object,
    // make it a Vector3, and multiple it by some force value 


}