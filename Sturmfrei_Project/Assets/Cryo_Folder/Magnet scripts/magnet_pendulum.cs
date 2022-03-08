using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class magnet_pendulum
{
    public Transform pono_tr;
    public magnet_tether tether;
    public magnet_arm arm;
    public magnet_pono pono;

    Vector3 previousPosition;


    public void Initialise()
    {
        pono_tr.transform.parent = tether.tether_tr;
        arm.length = Vector3.Distance(pono_tr.transform.localPosition, tether.position);
    }

    public Vector3 MovePono(Vector3 pos, float time)
    {
        pono.velocity += GetConstrainedVelocity(pos, previousPosition, time);
        pono.ApplyGravity();
        pono.ApplyDamping();
        pono.CapMaxSpeed();

        pos += pono.velocity * time;

        if (Vector3.Distance(pos,tether.position) < arm.length)
        {
            pos = Vector3.Normalize(pos - tether.position) * arm.length;
            arm.length = (Vector3.Distance(pos, tether.position));
            return pos;
        }

        previousPosition = pos;

        return pos;
    }

    public Vector3 MovePono(Vector3 pos, Vector3 prevPos, float time)
    {
        pono.velocity += GetConstrainedVelocity(pos, prevPos, time);
        pono.ApplyGravity();

        pos += pono.velocity * time;

        if (Vector3.Distance(pos, tether.position) < arm.length)
        {
            pos = Vector3.Normalize(pos - tether.position) * arm.length;
            arm.length = (Vector3.Distance(pos, tether.position));
            return pos;
        }

        previousPosition = pos;

        return pos;
    }

    public Vector3 GetConstrainedVelocity(Vector3 currentPos, Vector3 previousPosition, float time)
    {
        float distanceToTether;
        Vector3 constrainedPosition;
        Vector3 predictedPosition;

        distanceToTether = Vector3.Distance(currentPos, tether.position);
        if (distanceToTether > arm.length)
        {
            constrainedPosition = Vector3.Normalize(currentPos - tether.position) * arm.length;
            predictedPosition = (constrainedPosition - previousPosition) / time;
            return predictedPosition;
        }
        return Vector3.zero;
    }

    public void SwitchTether(Vector3 newPosition)
    {
        pono_tr.transform.parent = null;
        tether.tether_tr.position = newPosition;
        pono_tr.transform.parent = tether.tether_tr;
        tether.position = tether.tether_tr.InverseTransformPoint(newPosition);
        arm.length = Vector3.Distance(pono_tr.transform.localPosition, tether.position);
    }

    public Vector3 Fall(Vector3 pos, float time)

    {
        pono.ApplyGravity();

        pos += pono.velocity * time;
        return pos;
 
    }

  
}
