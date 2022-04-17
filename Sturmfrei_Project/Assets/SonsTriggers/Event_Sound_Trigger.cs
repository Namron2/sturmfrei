using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_Sound_Trigger : MonoBehaviour
{
    public Collider collider_Player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            collider_Player = other;
            collider_Player.GetComponent<PlayerCollisionSphere>().PlayerMov.gameObject.GetComponentInChildren<EventsPonoAnim>().Foot_Interaction();
        }
    }
}
