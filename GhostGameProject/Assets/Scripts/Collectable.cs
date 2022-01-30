using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    // logic
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log(coll.name);
        if (coll.name == "GhostBuddy_Front_1")
        OnCollect();
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
