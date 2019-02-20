using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticky_collide : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "sticky")
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
