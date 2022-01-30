using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : Collidable
{

    public GameObject player;


    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "TrainSprite")
            player.GetComponent<Player>().Die();
    }
}
