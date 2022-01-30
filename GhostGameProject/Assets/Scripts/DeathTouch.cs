using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : Collidable
{

    public GameObject player;


    protected override void OnCollide(Collider2D coll)
    {
        //List things that will kill you here
        if (coll.name == "TrainSprite")
        {
            player.GetComponent<Player>().Die();
            //Debug.Log("Death comes for us all");
            //Debug.Log(coll.name);
        }


        //experiment. list things that you collected here
        //if (coll.name == "GhostBuddy_Front_1")
        //{
        //    Debug.Log("Ghost freed");
        //}
    }
}
