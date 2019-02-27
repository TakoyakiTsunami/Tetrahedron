using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.GetComponent<LaunchSprite>());
        if (other.gameObject.GetComponent<LaunchSprite>())
        {
            gameObject.SetActive(false);
            //var scoreScript = other.gameObject.GetComponent("Score Counter");
            //scoreScript.score += 1;
            Debug.Log("coin collision registered");
        }
    }
}
