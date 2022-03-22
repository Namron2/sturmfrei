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
    public Transform playaTransform;
    public bool verticalGrappleZ;
    public bool verticalGrappleX;
    public bool horizontalGrapple;


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
        playaTransform = playa.transform;
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
        grappleScript.StopGrapple(); // devrait etre impossible
    }

    //this does not work


    private void Update()
    {

        if (isInsideMe)
        {
            if (Input.GetButtonDown("Grapple"))
            {
                //playa.gameObject.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z);
                grappleScript.StartGrapple();
            }
            else if (Input.GetButtonUp("Grapple"))
            {
                grappleScript.StopGrapple();
            }
        }


    }
}
