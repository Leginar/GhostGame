using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeController : MonoBehaviour
{

    public bool wipeUp = true;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wipeUp = true && transform.position.y < 54)
        {
            transform.Translate(0, + speed * Time.deltaTime, 0);
        }
        if (wipeUp = false && transform.position.y > -10)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
    }
}
