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
    public bool lookingAtWall = false;

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
            if (!isGrappledFollow && !Target.amDead)
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
            }
        }
        else
        {
            LerpCamToward(Target.gameObject);
        }

    }

    public void GrappleCam()
    {
        //camPos = 
        //Debug.Log("Moved");
        transform.position = camPos.transform.position;
        //this.gameObject.transform = camPos;
        //LookAtPos = target.position;

    }

    public void LerpCamToward(GameObject obj)
    {

    }

}
