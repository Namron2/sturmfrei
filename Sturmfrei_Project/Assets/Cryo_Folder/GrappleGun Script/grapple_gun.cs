using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapple_gun : MonoBehaviour
{

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    public PlayerCollisionSphere playerRigid;
    private Rigidbody tempoRigid;
    public GameObject magneticBall;
    private float enterSpeed;
    private PlayerMovement playMov;
    public CameraFollow camFol;
    public CameraFollowTarget camFolTarg;
    private bool LerpDistance;
    float elapsedTime;
    public float GrappleTime;


    public magnetic magnetic_script;
    public bool lacheSeul = false;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        tempoRigid = playerRigid.GetComponent<Rigidbody>();
        player = this.gameObject.transform;
        playMov = player.GetComponent<PlayerMovement>();
        //camFol = player.GetComponentInChildren<CameraFollow>();
        LerpDistance = false;
        GrappleTime = 4;
    }


    //Called after Update
    void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    public void StartGrapple()
    {
        /*RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point; // doit etre le centre de l'element magnetic
            joint = tempoRigid.gameObject.AddComponent<SpringJoint>();
        //tempoRigid = player.gameObject.GetComponent<Rigidbody>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }*/
        if (magneticBall != null)
        {
            Debug.Log("Grapple_ON");
            lacheSeul = false;
            //LerpDistance = false;
            PlayerMovement playMov = player.GetComponent<PlayerMovement>();
            playMov.SetGrappling();
            //camFol.DistanceFromPlayer = 20;
            enterSpeed = playMov.ActSpeed;
            grapplePoint = magneticBall.transform.position; // doit etre le centre de l'element magnetic
            joint = tempoRigid.gameObject.AddComponent<SpringJoint>();
            //tempoRigid = player.gameObject.GetComponent<Rigidbody>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //player.position = new Vector3(grapplePoint.x, grapplePoint.y, grapplePoint.z);
            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;

            camFol.isGrappled = true;
            camFolTarg.isGrappledFollow = true;
            camFolTarg.camPos = magnetic_script.Camera_Magnetic.gameObject;


            StartCoroutine(LacheTuSeul());
        }

    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    public void StopGrapple()
    {
        //player.GetComponent<PlayerMovement>().SetFlying();
        if (playMov.PreviousState == PlayerMovement.WorldState.Flying)
        {
            playMov.SetFlying();
        }
        else if (playMov.PreviousState == PlayerMovement.WorldState.InAir)
        {
            playMov.SetInAir();
        }
        lr.positionCount = 0;
        Destroy(joint);

        //camFol.DistanceFromPlayer = Mathf.Lerp(camFol.DistanceFromPlayer, 9, 0.5f);
        LerpDistance = true;
        // this seems to cause a shadow dash
        playMov.ActSpeed = enterSpeed + 5;
        //Destroy(tempoRigid);
        camFol.isGrappled = false;
        camFolTarg.isGrappledFollow = false;
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }


    IEnumerator LacheTuSeul()
    {
        yield return new WaitForSeconds(GrappleTime);
        lacheSeul = true;
        //StopGrapple();
    }
    public float progressLache = 0;
    private IEnumerator LacheTuSeul2()
    {
        while (progressLache <= 1)
        {
            elapsedTime += Time.unscaledDeltaTime;
            progressLache = elapsedTime / GrappleTime;

            yield return null;
        }
        lacheSeul = true;
    }
}
