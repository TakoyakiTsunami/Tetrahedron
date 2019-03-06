using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCollision : MonoBehaviour
{

    public bool isSticky;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.GetComponent<LaunchSprite>());
        if (collision.gameObject.GetComponent<LaunchSprite>())
        {
            var ls = collision.gameObject.GetComponent<LaunchSprite>();
            if (isSticky || (ls.remainingBounceCount == 0))
            {
                Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                playerRb.velocity = new Vector2(0, 0);
                playerRb.angularVelocity = 0;
                collision.gameObject.transform.Rotate(new Vector3(0, 0, 0));
                ls.setState(0);
                ls.resetBounceCount();
                //Debug.Log("Sticky Collision registered, set state to launchable");
            }
            else
            {
                ls.remainingBounceCount--;
            }
        }
    }
}
