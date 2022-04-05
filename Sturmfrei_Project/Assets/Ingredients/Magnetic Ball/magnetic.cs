using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnetic : MonoBehaviour
{
    private PlayerCollisionSphere playerRigid;
    private PlayerMovement playa;
    private grapple_gun grappleScript;
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
        isInsideMe = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("JeSors");
        //StopCoroutine(grappleScript.LacheTuSeul2()); //besoin d'arreter le coroutine pour la reset 
        grappleScript.progressLache = 0;
        grappleScript.elapsedTimes = 0;
        isInsideMe = false;
        grappleScript.lacheSeul = false;/*
        if (playa.States == PlayerMovement.WorldState.Grappling)
        {
            //grappleScript.StopGrapple();
            grappleScript.lacheSeul = false;
            Debug.Log("JeSaisPasSiJeSuisUtile");
        }*/
    }


    private void Update()
    {

        if (isInsideMe)
        {
            if (Input.GetButtonDown("Grapple"))
            {
                //playa.gameObject.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z);
                grappleScript.StartGrapple();
            }
            else if (Input.GetButtonUp("Grapple") || grappleScript.lacheSeul)
            {
                grappleScript.StopGrapple();
                grappleScript.lacheSeul = false;
            }
        }
        else
        {
            if(grappleScript !=null) grappleScript.lacheSeul = false;
        }


    }
}
