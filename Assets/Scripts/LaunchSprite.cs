// MoveRotation
// The sprite is set a rotation speed.

using UnityEngine;
using System.Collections;

public class LaunchSprite : MonoBehaviour
{
    public float speedRotate;
    private Rigidbody2D rb2D;

    public KeyCode pressUp;
    public KeyCode pressDown;
    public KeyCode pressLeft;
    public KeyCode pressRight;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown (pressUp))
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetKeyDown (pressLeft))
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 90);

        if (Input.GetKeyDown(pressRight))
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, -90);

        if (Input.GetKeyDown(pressDown))
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 180);
        //transform.Rotate(Vector3.forward * speedRotate * Time.deltaTime);
    }
}