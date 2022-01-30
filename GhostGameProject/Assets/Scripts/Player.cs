using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer thisRenderer;
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public float stateTimer = 0;
    private int transitionState = 0;// 0 = no state, 1 = Dying, 2 = Ressurecting
    public Sprite playerRear;
    public Sprite playerFront;

    public GameObject DeathParticleEffect;
    public GameObject CorpseDrop;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        thisRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset MoveDelta
        moveDelta = new Vector3(x, y, 0);

        //check death button

        if (Input.GetButton("Fire1") && transitionState == 0)
        {
            transitionState = 1;
            stateTimer = 1;
            Instantiate(DeathParticleEffect, transform);
            Instantiate(CorpseDrop, transform);
        }

        //check ressurect button

        if (Input.GetButton("Fire2") && transitionState == 0)
        {
            transitionState = 2;
            stateTimer = 1;
        }

        if (transitionState > 0 && stateTimer < 0) { transitionState = 0; }

        //reduce the stateTimer;

        if (stateTimer > 0) { stateTimer -= 1 * Time.deltaTime;  }



        //check to see that no transition is taking place
        if (transitionState == 0)
        {

            //Swap sprite direction wether you're going right or left
            if (moveDelta.x > 0)
            {
                thisRenderer.flipX = false;
            }

            else if (moveDelta.x < 0)
            {
                thisRenderer.flipX = true;
            }

            //Swap sprite wether you're going up or down
            if (moveDelta.y > 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = playerRear;
            }

            else if (moveDelta.y < 0)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = playerFront;
            }


            // Make sure we can move in this direction by casing a box there first, if the box
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                //Make this thing move
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            }

            // Make sure we can move in this direction by casing a box there first, if the box
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
            if (hit.collider == null)
            {
                //Make this thing move
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            }

        }

    }
}
