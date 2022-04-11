using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentEolienne : MonoBehaviour
{
    public int burstValue = 20;
    public GameObject pono;
    PlayerMovement playerMovement;
    public string state;

    private void OnTriggerStay(Collider other)
    {
        pono = GameObject.Find("PonoPrefab#03");
        playerMovement = pono.GetComponent<PlayerMovement>();
        state = playerMovement.States.ToString();

        if (other.gameObject.tag == "Player" && state == "Flying")
        {
            other.GetComponent<Rigidbody>().AddForce((-transform.up * burstValue), ForceMode.Impulse);
            //-transform.up pousse en avant a cause de la direction du collider capsule
        }
    }
}
