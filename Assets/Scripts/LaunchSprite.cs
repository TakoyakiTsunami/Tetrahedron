// MoveRotation
// The sprite is set a rotation speed.

using UnityEngine;
using System.Collections;

public class LaunchSprite : MonoBehaviour
{
    private Rigidbody2D rb;

    public float thrust = 50;
    public float rotation = 5.0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        // Make sprite launch on spacebar press
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up);
        }
        else
        {
            rotation += Input.GetAxis("Horizontal");

            // gameObject refers to object this script is attached to
            gameObject.transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }
}