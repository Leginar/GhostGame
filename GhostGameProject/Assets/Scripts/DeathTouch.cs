using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTouch : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "TrainSprite")
        Debug.Log("Dead");
    }
}
