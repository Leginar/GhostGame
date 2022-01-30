using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private bool hasTarget = false;
    private int targetPriority = 0; // 0-3 no target, 4 train spotted, 5 player spotted

    public GameObject player;
    public GameObject train;

    public float speed = 10;

    public float targetX = 0;
    public float targetY = 0;

    public float timer = -3; //timer goes up to 35. Enemy can move during 0-10


    // Start is called before the first frame update
    void Start()
    {
        targetX = transform.position.x + Random.Range(-16f, 16f);
        targetY = transform.position.y + Random.Range(-16f, 16f);
    }


    // Update is called once per frame
    void Update()
    {

        //movement

        if (timer < 0.11f && timer > 0f)
        {

            if (transform.position.x > targetX) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
            if (transform.position.x < targetX) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        }

        if (timer < 0.17f && timer > 0.06f)
        { 

            if (transform.position.y > targetY) { transform.Translate(0, -speed * Time.deltaTime, 0); }
            if (transform.position.y < targetY) { transform.Translate(0, speed * Time.deltaTime, 0); }

        }



        // Timer and hops (3 hops before picking new target)
        timer += 1f * Time.deltaTime;
        if (timer > 0.5f)
        {
            timer -= 0.5f;
            float temprandom = Random.Range(0f, 10f);
            if (temprandom > 8) timer -= 1;
            if (targetPriority < 3) { targetPriority++; }
            if (targetPriority == 3)
            {
                targetPriority = 0;
                targetX = transform.position.x + Random.Range(-30f, 30f);
                targetY = transform.position.y + Random.Range(-30f, 30f);
            }
        }
    }
}
