using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitch : MonoBehaviour
{

    public GameObject WipeObject;
    double fadoutTime = 0; // over 100 = fading to overworld. under 0 = fading to deathworld

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fadoutTime > 100) { 
        //watch for timer end. If it ends fade out the wipe.
            fadoutTime -= 1 * Time.deltaTime; 
            if (fadoutTime < 100) {
                transform.Translate(-30, 0, 0); //Move to overworld
                WipeObject.GetComponent<WipeController>().wipeUp = true; 
            }
        }

        if (fadoutTime < 0)
        {
            //watch for timer end. If it ends fade out the wipe.
            fadoutTime += 1 * Time.deltaTime;
            if (fadoutTime > 0) {
                transform.Translate(30, 0, 0); //move to deathworld
                WipeObject.GetComponent<WipeController>().wipeUp = true; //fade out wipe
            }
        }
    }

   public void TeleportDeadworld()
    {
        WipeObject.GetComponent<WipeController>().wipeUp = false;
        fadoutTime = -1;
        
    }

    public void TeleportOverworld()
    {
        WipeObject.GetComponent<WipeController>().wipeUp = false;
        fadoutTime = 101;
    }
}
