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


    // Update is called once per frame
    void Update()
    {
        if (!isGrappledFollow)
        {
            Vector3 MPos = Target.transform.position;

            if (Target.Rigid != null)
                MPos = Target.Rigid.position;

            transform.position = MPos + (OffsetDirection.up * Offset);
        }
        else
        {
            GrappleCam();
        }
    }

    public void GrappleCam()
    {
        //camPos = 
        Debug.Log("Moved");
        transform.position = camPos.transform.position;
        //this.gameObject.transform = camPos;
        //LookAtPos = target.position;

    }
}
