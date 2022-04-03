using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animShrine : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Animator>().SetBool("PonoProche", true);
        }

        if (Input.GetKeyDown("space"))
        {
            this.gameObject.GetComponent<Animator>().SetTrigger("SetCheckpoint");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<Animator>().SetBool("PonoProche", false);
        }
    }
}
