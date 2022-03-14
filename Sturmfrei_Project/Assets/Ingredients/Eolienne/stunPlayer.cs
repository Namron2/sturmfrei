using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunPlayer : MonoBehaviour
{
    public PlayerMovement player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<PlayerCollisionSphere>().PlayerMov;
            player.Stunned(-player.transform.forward);
        }
    }
}
