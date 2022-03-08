using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust_Devil : MonoBehaviour
{

    public int burstValue = 75;
    private void OnTriggerEnter(Collider other)
    {
        PlayerCollisionSphere Player = other.GetComponent<PlayerCollisionSphere>();

        if (!Player)
            return;

        Player.GetComponent<Rigidbody>().AddForce((Vector3.up * burstValue), ForceMode.Impulse);
    }
}
