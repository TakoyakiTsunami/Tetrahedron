// MoveRotation
// The sprite is set a rotation speed.

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LaunchSprite : MonoBehaviour
{
    public enum CharacterState
    {
        Landed,
        Launchable, // Switch Launchable to Launching
        InAir
    }

    private int MAXBOUNCECOUNT = 1;
    public int remainingBounceCount;

    private CharacterState state;

    private Rigidbody2D rb;
    public float thrust;

    private float rotation = 5.0f;
    private float thrustLimit = 100;
    public Text powerText;

    public Slider powerSlider;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        thrust = 1;
        state = CharacterState.Launchable;
        remainingBounceCount = MAXBOUNCECOUNT;

        // Initialize value of the text component
        setPowerText ();

    }

    void Update()
    {
        Debug.Log("SLIDER VALUE: " + powerSlider.value);

        if (state == CharacterState.Launchable && Input.GetKey(KeyCode.Space) && thrust < thrustLimit)
        {
            thrust += Time.deltaTime * 5;
            setPowerText();
            updatePowerSlider();
            Debug.Log("Power: " + thrust);
        }


        // Cancel launching 
        if (state == CharacterState.Launchable && Input.GetKey(KeyCode.LeftShift))
        {
            state = CharacterState.Landed;
            Debug.Log("ABORT LAUNCHING!" + state);
        }
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

    void setPowerText()
    {
        powerText.text = "Power: " + thrust.ToString();
    }

    void updatePowerSlider()
    {
        powerSlider.value += thrust / 100;
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