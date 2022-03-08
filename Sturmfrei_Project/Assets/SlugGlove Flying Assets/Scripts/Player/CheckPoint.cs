using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    DeathZone deathZone;
    private void Start()
    {
        deathZone = GameObject.Find ("DeathZone").GetComponent<DeathZone>();
    }
    void OnTriggerEnter (Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            deathZone.respawnPoint = gameObject.transform.position;
        }
    }
}
