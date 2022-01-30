using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Collectable
{
    protected override void OnCollide(Collider2D coll)
    {
        Debug.Log("You got a ghost!");
    }
}