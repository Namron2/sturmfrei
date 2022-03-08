using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustDevilAscenseur : MonoBehaviour
{
    //private Rigidbody quiMonte;
    //public float hauteur;

    private PlayerCollisionSphere quiMonte;
    private Rigidbody quiMonteRigid;
    private GameObject colliderPlayer;
    private PlayerMovement player;

    //donne une velocite verticale
    private void OnTriggerEnter(Collider other)
    {
        colliderPlayer = other.gameObject;
        if (colliderPlayer.tag == "Player")
        {
            quiMonte = other.GetComponent<PlayerCollisionSphere>();
            quiMonteRigid = quiMonte.GetComponent<Rigidbody>();
            quiMonteRigid.velocity = Vector3.up * 8f;
            player = quiMonte.PlayerMov;
        }
    }

    //desactive la gravite pour que eviter conflit avec vector3 up
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            quiMonteRigid.useGravity = false;
            if (player.GetComponent<PlayerMovement>().States == PlayerMovement.WorldState.InAir)
            {
                quiMonteRigid.AddForce(transform.up * 2f);
            }
            else if (player.GetComponent<PlayerMovement>().States == PlayerMovement.WorldState.Flying)
            {
                //quiMonteRigid.AddForce(transform.up * 2000f);
                quiMonteRigid.AddForce((Vector3.up * 50f),ForceMode.Impulse);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            quiMonteRigid.useGravity = true;
        }
    }
}
