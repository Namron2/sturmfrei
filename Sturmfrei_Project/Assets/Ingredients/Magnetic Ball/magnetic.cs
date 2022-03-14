using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetic : MonoBehaviour
{
    private PlayerCollisionSphere playerRigid;
    private PlayerMovement playa;
    private grapple_gun grappleScript;
    public PonchoColourChange sturm;
    public bool isInsideMe = false;

    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Press Left-Mouse or X on controller");
        playerRigid = other.GetComponent<PlayerCollisionSphere>();
        playa = playerRigid.PlayerMov;
        grappleScript = playa.gameObject.GetComponent<grapple_gun>();
        grappleScript.magneticBall = this.gameObject.transform.parent.gameObject;
        //sturm = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PonchoColourChange>();
        if (sturm != null) sturm.GoldPoncho();
        isInsideMe = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(sturm!=null) sturm.NoMoreGold();
        isInsideMe = false;
        grappleScript.StopGrapple(); // devrait être impossible
    }

    private void Update()
    {
        if (isInsideMe)
        {
            if (Input.GetButtonDown("Grapple"))
            {
                grappleScript.StartGrapple();
            }
            else if (Input.GetButtonUp("Grapple"))
            {
                grappleScript.StopGrapple();
            }
        }

    }
}
