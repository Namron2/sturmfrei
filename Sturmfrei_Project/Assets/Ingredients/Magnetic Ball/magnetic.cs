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
    public GameObject Camera_Magnetic;
    private GameObject parent;

    private void Awake()
    {
         parent= this.gameObject.transform.parent.gameObject;
        Camera_Magnetic = parent.transform.Find("Camera_Position").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Press Left-Mouse or X on controller");
        playerRigid = other.GetComponent<PlayerCollisionSphere>();
        playa = playerRigid.PlayerMov;
        grappleScript = playa.gameObject.GetComponent<grapple_gun>();
        grappleScript.magnetic_script = this;
        grappleScript.magneticBall = parent;
        //sturm = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PonchoColourChange>();
        if (sturm != null) sturm.GoldPoncho();
        isInsideMe = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(sturm!=null) sturm.NoMoreGold();
        isInsideMe = false;
        grappleScript.StopGrapple(); // devrait �tre impossible
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
