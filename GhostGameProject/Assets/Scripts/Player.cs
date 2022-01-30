using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer thisRenderer;
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public float stateTimer = 0; // < 0 = moving to death.  > 100 fading to overworld
    private int transitionState = 0;// 0 = no state, 1 = Dying, 2 = Ressurecting
    public int world = 1; //1 = overworld, 2 = deadworld
    public Sprite playerRear;
    public Sprite playerFront;

    public GameObject DeathParticleEffect;
    public GameObject ResParticleEffect;
    public GameObject Camera;
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

        //Collision
        //hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Character", "Collision"));
        //if (hit.collider == null)

        //check death button

        if (Input.GetButton("Fire1") && transitionState == 0 && world == 1)
        {
            transitionState = 1;
            stateTimer = -1;
            GameObject tempParticle = Instantiate(DeathParticleEffect);
            tempParticle.transform.position = transform.position;
            GameObject tempCorpse = Instantiate(CorpseDrop);
            tempCorpse.transform.position = transform.position;
            Camera.GetComponent<WorldSwitch>().TeleportDeadworld();
            transform.Translate(+30, 0, 0);
        }

        //check ressurect button

        if (Input.GetButton("Fire2") && transitionState == 0 && world == 2)
        {
            transitionState = 2;
            stateTimer = 101.2f;
            GameObject tempParticle = Instantiate(ResParticleEffect);
            tempParticle.transform.position = transform.position;
            Camera.GetComponent<WorldSwitch>().TeleportOverworld();
            GameObject tempParticle2 = Instantiate(ResParticleEffect);
            tempParticle2.transform.position = new Vector3(transform.position.x-30, transform.position.y, transform.position.z);

        }

   

        if (transitionState > 0 && stateTimer > 0  && stateTimer < 100) { transitionState = 0; }

        //reduce the stateTimer;

        if (stateTimer > 100)
        { //fading to overworld timer
            stateTimer -= 1 * Time.deltaTime;
            if (stateTimer <= 100) {
                
                world = 1; //arriving in overworld
                transform.Translate(-30, 0, 0);

            }

            } 

        if (stateTimer < 0)
        { //fading to death timer
            stateTimer += 1 * Time.deltaTime;
            if (stateTimer >= 0) 
            {
               
                world = 2; //arriving in death
            }
        } 



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
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Character", "Collision"));
            if (hit.collider == null)
            {
                //Make this thing move
                transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            }

            // Make sure we can move in this direction by casing a box there first, if the box
            hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Character", "Collision"));
            if (hit.collider == null)
            {
                //Make this thing move
                transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
            }

        }

    }
}
