using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Vector3 respawnPoint;
    public Collider collider_Player;
    public CameraFollow camFol;
    //public Transform Death_Pos;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            collider_Player = other;
            collider_Player.GetComponent<PlayerCollisionSphere>().PlayerMov.amDead = true;
            camFol = collider_Player.GetComponent<PlayerCollisionSphere>().PlayerMov.CamFol;
            camFol.isDead = collider_Player.GetComponent<PlayerCollisionSphere>().PlayerMov.amDead;
            //GameObject.Find("Pono#05").gameObject.GetComponent<EventsPonoAnim>().Fall_Respawn();
            collider_Player.GetComponent<PlayerCollisionSphere>().PlayerMov.gameObject.GetComponentInChildren<EventsPonoAnim>().Fall_Respawn();
            StartCoroutine(Dead_Respawn());
        }
    }

    private IEnumerator Dead_Respawn()
    {
        //Fade to black
        PlayerMovement player = collider_Player.GetComponent<PlayerCollisionSphere>().PlayerMov;
        player.StartFade();
        yield return new WaitForSeconds(2);
        respawnPoint = player.gameObject.GetComponent<PlayerRespawn>().respawnPoint;
        player.amDead = false;
        camFol.isDead = player.amDead;
        //Fade in instant
        collider_Player.transform.position = respawnPoint;
        yield return new WaitForSeconds(1f);
        player.RemoveFade();
    }
}

