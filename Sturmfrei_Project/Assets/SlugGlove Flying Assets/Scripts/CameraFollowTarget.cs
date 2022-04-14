using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{

    public PlayerMovement Target;
    public float Offset;
    public Transform OffsetDirection;

    public bool isGrappledFollow;
    public GameObject camPos;
    public CameraFollow camFol;
    public Vector3 Cam_Pos_Unlock;
    public bool lookingAtWall = false;

    public bool ReturnHub = false;

    private void Start()
    {
        camFol = this.gameObject.GetComponent<CameraFollow>();
    }
    // Update is called once per frame
    void Update()
    {
        camFol.lookWall = lookingAtWall;
        if (!lookingAtWall)
        {
            if (!isGrappledFollow && !Target.amDead && !ReturnHub)
            {
                Vector3 MPos = Target.transform.position;

                if (Target.Rigid != null)
                    MPos = Target.Rigid.position;

                transform.position = MPos + (OffsetDirection.up * Offset);
            }
            else
            {
                if (isGrappledFollow)
                {
                    GrappleCam();
                }
                if (Target.amDead)
                {

                }
                if(ReturnHub)
                {

                }
            }
        }
        else
        {
            // lerp dat shit boi
            if (Cam_Pos_Unlock != null)
            {
                Target.ActSpeed = 0;
                Target.Anim.SetFloat("Moving", 0);
                Target.Rigid.transform.position = Target.transform.position;
                Target.Rigid.velocity = Vector3.zero;
                transform.position = Vector3.Lerp(transform.position, Cam_Pos_Unlock, 1 * Time.deltaTime);
            }
        }
    }

    public void GrappleCam()
    {
        transform.position = camPos.transform.position;
    }


}
