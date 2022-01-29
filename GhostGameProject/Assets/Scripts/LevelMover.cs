using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMover : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        if ( transform.position.y < -38 ) transform.Translate(0, +80, 0); 

        //640 pixels in chunk

    }
}
