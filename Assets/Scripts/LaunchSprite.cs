// MoveRotation
// The sprite is set a rotation speed.

using UnityEngine;
using System.Collections;

public class LaunchSprite : MonoBehaviour
{
    public enum CharacterState
    {
        Launchable,
        InAir
    }

    private int MAXBOUNCECOUNT = 1;
    public int remainingBounceCount;

    private CharacterState state;

    private Rigidbody2D rb;

    public float thrust = 1;
    private float rotation = 5.0f;
    private float thrustLimit = 100;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = CharacterState.Launchable;
        remainingBounceCount = MAXBOUNCECOUNT;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (state == CharacterState.Launchable && thrust < thrustLimit)
            {
                thrust += Time.deltaTime * 5;
                Debug.Log("Power: " + thrust);
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (state == CharacterState.Launchable)
            {
                rb.AddRelativeForce(Vector3.up * thrust);
                state = CharacterState.InAir;
                thrust = 1;
            }
        }

        

        else if (Input.GetAxis("Horizontal") != 0.0f)
        {
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

    public void setState(int NewState)
    {
        state = (CharacterState)NewState;
        Debug.Log("set character state to " + ((CharacterState)NewState).ToString());
    }

    public void resetBounceCount()
    {
        remainingBounceCount = MAXBOUNCECOUNT;
    }
}