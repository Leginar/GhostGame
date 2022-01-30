using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Collectable
{
    public Sprite freeGhost;
    public int ghostAmount = +1;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            //GetComponent<SpriteRenderer>().sprite = freeGhost;
            Debug.Log("You have" + ghostAmount + "ghosts!");
        } 
    }
}